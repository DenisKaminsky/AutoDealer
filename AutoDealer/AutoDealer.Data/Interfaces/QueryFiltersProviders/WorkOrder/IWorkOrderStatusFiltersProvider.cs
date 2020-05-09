using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.WorkOrder;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder
{
    public interface IWorkOrderStatusFiltersProvider : IBaseFiltersProvider<WorkOrderStatus>
    {
    }
}
