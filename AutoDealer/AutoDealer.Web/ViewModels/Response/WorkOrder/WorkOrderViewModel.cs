using System;
using System.Collections.Generic;
using AutoDealer.Web.ViewModels.Response.User;

namespace AutoDealer.Web.ViewModels.Response.WorkOrder
{
    public class WorkOrderViewModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public UserContactInfoViewModel Worker { get; set; }
        public WorkOrderStatusViewModel Status { get; set; }
        public WorkOrderClientViewModel Client { get; set; }
        public int TotalPrice { get; set; }
        public IEnumerable<WorkViewModel> Works { get; set; }
    }
}
