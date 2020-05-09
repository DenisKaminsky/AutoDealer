using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.WorkOrder
{
    public class WorkOrderStatus : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }
    }
}
