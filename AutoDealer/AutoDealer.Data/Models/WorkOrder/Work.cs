using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.WorkOrder.Relations;

namespace AutoDealer.Data.Models.WorkOrder
{
    public class Work : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public IEnumerable<WorkOrderHasWorks> Orders { get; set; }
    }
}
