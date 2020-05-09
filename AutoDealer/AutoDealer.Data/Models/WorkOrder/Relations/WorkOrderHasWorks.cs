using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.WorkOrder.Relations
{
    public class WorkOrderHasWorks : BaseModel
    {
        public int OrderId { get; set; }
        public WorkOrder Order { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}
