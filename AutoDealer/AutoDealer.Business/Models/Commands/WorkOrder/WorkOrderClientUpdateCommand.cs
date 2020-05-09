using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.WorkOrder
{
    public class WorkOrderClientUpdateCommand : WorkOrderClientCreateCommand, IUpdateCommand
    {
        public int Id { get; set; }
    }
}
