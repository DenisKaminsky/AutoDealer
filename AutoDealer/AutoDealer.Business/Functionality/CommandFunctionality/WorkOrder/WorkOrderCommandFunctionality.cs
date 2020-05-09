using System;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Exceptions;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.WorkOrder
{
    public class WorkOrderCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<WorkOrderCreateCommand, Data.Models.WorkOrder.WorkOrder>, IWorkOrderCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IWorkOrderFiltersProvider _orderFiltersProvider;
        private readonly IWorkFiltersProvider _workFiltersProvider;

        public WorkOrderCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IWorkOrderFiltersProvider orderFiltersProvider, IWorkFiltersProvider workFiltersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _orderFiltersProvider = orderFiltersProvider;
            _workFiltersProvider = workFiltersProvider;
        }

        public override async Task<int> AddAsync(WorkOrderCreateCommand createCommand)
        {
            await ValidatorFactory.GetValidator<WorkOrderCreateCommand>().ValidateAndThrowAsync(createCommand);

            var works = await _readRepository.GetAsync(_workFiltersProvider.ByIds(createCommand.WorksIds.Distinct()));
            var item = Mapper.Map<Data.Models.WorkOrder.WorkOrder>(createCommand);
            item.TotalPrice = works.Sum(x => x.Price);
            await WriteRepository.AddAsync(item);
            await UnitOfWork.CommitAsync();

            return item.Id;
        }

        public async Task CompleteAsync(int orderId)
        {
            var item = await _readRepository.GetSingleAsync(_orderFiltersProvider.ById(orderId));

            if (item == null)
                throw new NotFoundException("Item was not found!");

            item.CompletedDate = DateTime.UtcNow.Date;
            item.StatusId = (int)WorkOrderStatuses.Completed;

            await WriteRepository.UpdateAsync(item);
            await UnitOfWork.CommitAsync();
        }
    }
}
