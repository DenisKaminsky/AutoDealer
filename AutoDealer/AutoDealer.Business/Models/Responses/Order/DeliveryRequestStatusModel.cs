namespace AutoDealer.Business.Models.Responses.Order
{
    public class DeliveryRequestStatusModel : BaseModel
    {
        public string Name { get; }

        public DeliveryRequestStatusModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
