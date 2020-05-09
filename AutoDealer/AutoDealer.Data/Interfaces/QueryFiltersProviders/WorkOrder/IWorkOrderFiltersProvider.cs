using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder
{
    public interface IWorkOrderFiltersProvider : IBaseFiltersProvider<Models.WorkOrder.WorkOrder>
    {
        Expression<Func<Models.WorkOrder.WorkOrder, bool>> ByWorkerId(int id);
    }
}
