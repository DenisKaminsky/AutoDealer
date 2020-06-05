using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Order
{
    public class OrderCreateCommand : ICreateCommand
    {
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
    }
}
