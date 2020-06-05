using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Order;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Order
{
    public class OrderCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<OrderCreateCommand, Data.Models.Order.Order>, IOrderCommandFunctionality
    {
        public OrderCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public async Task<int> AddWithOrderAsync(OrderCreateCommand command)
        {
            await ValidatorFactory.GetValidator<OrderCreateCommand>().ValidateAndThrowAsync(command);

            await UnitOfWork.BeginTransactionAsync();
            var item = Mapper.Map<Data.Models.Order.Order>(command);
            item.DeliveryRequest = Mapper.Map<DeliveryRequest>(command);

            await WriteRepository.AddAsync(item);
            await UnitOfWork.CommitAsync();
            return item.Id;
        }
    }
}
