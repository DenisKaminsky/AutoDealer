using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.WorkOrder;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.RelationsProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.WorkOrder
{
    public class WorkOrderQueryFunctionality : BaseQueryFunctionality, IWorkOrderQueryFunctionality
    {
        private readonly IWorkOrderFiltersProvider _filtersProvider;
        private readonly IWorkOrderRelationProvider _relationProvider;

        public WorkOrderQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IWorkOrderFiltersProvider filtersProvider, IWorkOrderRelationProvider relationProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationProvider = relationProvider;
        }

        public async Task<IEnumerable<WorkOrderModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllQueryableAsync<Data.Models.WorkOrder.WorkOrder>(_relationProvider.JoinAll);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(items);
        }

        public async Task<WorkOrderModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationProvider.JoinAll);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<WorkOrderModel>(item);
        }

        public async Task<IEnumerable<WorkOrderModel>> GetByWorkerIdAsync(int workerId)
        {
            var items = await ReadRepository.GetQueryableAsync(_filtersProvider.ByWorkerId(workerId), _relationProvider.JoinAll);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(items);
        }
    }
}
