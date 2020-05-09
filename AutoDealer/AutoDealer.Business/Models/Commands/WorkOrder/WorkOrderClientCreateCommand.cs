using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.WorkOrder
{
    public class WorkOrderClientCreateCommand : ICreateCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
