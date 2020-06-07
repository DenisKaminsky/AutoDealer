using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.WorkOrder
{
    public class WorkOrderFiltersProvider : BaseFiltersProvider<Models.WorkOrder.WorkOrder>, IWorkOrderFiltersProvider
    {
        public Expression<Func<Models.WorkOrder.WorkOrder, bool>> ByWorkerId(int id)
        {
            return item => item.WorkerId == id;
        }

        public Expression<Func<Models.WorkOrder.WorkOrder, bool>> ByCreatedDate(DateTime startDate, DateTime endDate)
        {
            return item => item.CreatedDate >= startDate && item.CreatedDate <= endDate;
        }
    }
}
