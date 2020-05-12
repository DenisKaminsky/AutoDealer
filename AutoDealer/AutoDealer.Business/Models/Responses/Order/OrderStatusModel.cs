namespace AutoDealer.Business.Models.Responses.Order
{
    public class OrderStatusModel : BaseModel
    {
        public string Name { get; }

        public OrderStatusModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
