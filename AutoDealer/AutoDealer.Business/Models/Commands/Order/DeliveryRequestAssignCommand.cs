namespace AutoDealer.Business.Models.Commands.Order
{
    public class DeliveryRequestAssignCommand
    {
        public int SupplierManagerId { get; set; }
        public int DeliveryRequestId { get; set; }
    }
}
