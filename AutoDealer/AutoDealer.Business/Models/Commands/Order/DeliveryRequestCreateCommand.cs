using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Order
{
    public class DeliveryRequestCreateCommand : ICreateCommand
    {
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public int Amount { get; set; }
    }
}
