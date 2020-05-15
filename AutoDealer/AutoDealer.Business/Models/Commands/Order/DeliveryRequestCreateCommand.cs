using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Order
{
    public class DeliveryRequestCreateCommand : ICreateCommand
    {
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public int ColorId { get; set; }
        public int EngineGearboxId { get; set; }
        public int ComplectationId { get; set; }
        public int ManagerId { get; set; }
        public int Amount { get; set; }
    }
}
