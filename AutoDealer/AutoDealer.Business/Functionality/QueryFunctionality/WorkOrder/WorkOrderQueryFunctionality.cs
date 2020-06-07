using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Business.Models.Responses.WorkOrder;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.RelationsProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<StatisticsDateCountModel>> GetStatisticsForLastDays(uint daysCount)
        {
            var endDate = DateTime.UtcNow.Date;
            var startDate = endDate.AddDays(-daysCount);
            var query = await ReadRepository.GetQueryableAsync(_filtersProvider.ByCreatedDate(startDate, endDate));
            var items = await query
                .GroupBy(x => x.CreatedDate.Date)
                .Select(x => new { Date = x.Key, Count = x.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Count);

            for (var date = startDate; date < endDate; date = date.AddDays(1))
            {
                if (!items.ContainsKey(date))
                    items.Add(date, 0);
            }

            return items
                .Select(x => new StatisticsDateCountModel { Date = x.Key, Count = x.Value })
                .OrderBy(x => x.Date);
        }
    }
}
