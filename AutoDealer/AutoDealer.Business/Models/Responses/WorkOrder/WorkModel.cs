namespace AutoDealer.Business.Models.Responses.WorkOrder
{
    public class WorkModel : BaseModel
    {
        public string Name { get; }
        public int Price { get; }

        public WorkModel(int id, string name, int price) : base(id)
        {
            Name = name;
            Price = price;
        }
    }
}
