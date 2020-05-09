using System.Collections.Generic;
using AutoDealer.Business.Models.Commands.WorkOrder;

namespace AutoDealer.Web.ViewModels.Request.WorkOrder
{
    public class WorkOrderCreateViewModel
    {
        public WorkOrderClientCreateCommand Client { get; set; }
        public IEnumerable<int> WorksIds { get; set; }
    }
}
