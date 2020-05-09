using System;
using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.WorkOrder.Relations;

namespace AutoDealer.Data.Models.WorkOrder
{
    public class WorkOrder : BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int WorkerId { get; set; }
        public User.User Worker { get; set; }
        public int StatusId { get; set; }
        public WorkOrderStatus Status { get; set; }
        public int ClientId { get; set; }
        public WorkOrderClient Client { get; set; }
        public int TotalPrice { get; set; }
        public IEnumerable<WorkOrderHasWorks> Works { get; set; }
    }
}
