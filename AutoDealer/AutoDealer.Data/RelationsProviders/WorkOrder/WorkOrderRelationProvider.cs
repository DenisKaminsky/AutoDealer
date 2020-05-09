using AutoDealer.Data.Interfaces.RelationsProviders.WorkOrder;
using AutoDealer.Data.Models.WorkOrder.Relations;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.WorkOrder
{
    public class WorkOrderRelationProvider : BaseRelationsProvider, IWorkOrderRelationProvider
    {
        public string[] JoinAll { get; } =
        {
            $"{nameof(Models.WorkOrder.WorkOrder.Worker)}",
            $"{nameof(Models.WorkOrder.WorkOrder.Status)}",
            $"{nameof(Models.WorkOrder.WorkOrder.Client)}",
            $"{nameof(Models.WorkOrder.WorkOrder.Works)}.{nameof(WorkOrderHasWorks.Work)}"
        };
    }
}
