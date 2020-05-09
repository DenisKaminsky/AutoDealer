using System.Collections.Generic;
using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.WorkOrder
{
    public class WorkOrderCreateCommand : ICreateCommand
    {
        public int WorkerId { get; set; }
        public WorkOrderClientCreateCommand Client { get; set; }
        public IEnumerable<int> WorksIds { get; set; }
    }
}
