using System;
using System.Threading.Tasks;
using AutoDealer.Business.Control;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Order
{
    public class OrderCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<OrderFromStockCreateCommand, Data.Models.Order.Order>, IOrderCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;

        public OrderCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
        }

        public override async Task<int> AddAsync(OrderFromStockCreateCommand command)
        {
            using (await BusinessLocks.OrderCreateLock.LockAsync())
            {
                await ValidatorFactory.GetValidator<OrderFromStockCreateCommand>().ValidateAsync(command);

                await UnitOfWork.BeginTransactionAsync();
                var order = Mapper.Map<Data.Models.Order.Order>(command);
                var car = await _readRepository.GetByIdAsync<CarStock>(command.CarId);
                car.Amount--;

                await WriteRepository.AddAsync(order);
                await WriteRepository.UpdateAsync(car);
                await UnitOfWork.CommitAsync();
                return order.Id;
            }
        }

        public async Task<int> AddWithDeliveryRequestAsync(OrderWithDeliveryRequestCreateCommand command)
        {
            await ValidatorFactory.GetValidator<OrderWithDeliveryRequestCreateCommand>().ValidateAndThrowAsync(command);

            await UnitOfWork.BeginTransactionAsync();
            var item = Mapper.Map<Data.Models.Order.Order>(command);
            item.DeliveryRequest = Mapper.Map<DeliveryRequest>(command);

            await WriteRepository.AddAsync(item);
            await UnitOfWork.CommitAsync();
            return item.Id;
        }

        public async Task Promote(OrderPromoteCommand command)
        {
            using (await BusinessLocks.OrderPromotionLock.LockAsync())
            {
                await ValidatorFactory.GetValidator<OrderPromoteCommand>().ValidateAndThrowAsync(command);

                await UnitOfWork.BeginTransactionAsync();
                var order = await _readRepository.GetByIdAsync<Data.Models.Order.Order>(command.OrderId);
                var newStatus = order.StatusId + 1;
                if (newStatus == (int)OrderStatuses.Completed)
                {
                    order.CompletedDate = DateTime.UtcNow;
                }
                order.StatusId = newStatus;

                await WriteRepository.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
            }
        }
    }
}
