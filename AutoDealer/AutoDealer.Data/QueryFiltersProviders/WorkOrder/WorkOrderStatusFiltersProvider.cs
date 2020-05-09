using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.WorkOrder
{
    public class WorkOrderStatusFiltersProvider : BaseFiltersProvider<WorkOrderStatus>, IWorkOrderStatusFiltersProvider
    {
    }
}
