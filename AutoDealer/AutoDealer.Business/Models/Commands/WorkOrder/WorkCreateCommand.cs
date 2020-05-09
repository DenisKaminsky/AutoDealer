using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.WorkOrder
{
    public class WorkCreateCommand: ICreateCommand
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
