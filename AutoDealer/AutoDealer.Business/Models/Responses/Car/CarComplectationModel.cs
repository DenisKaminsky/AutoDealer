namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarComplectationModel : BaseModel
    {
        public string Name { get; }
        public int Price { get; }
        public int ModelId { get; }

        public CarComplectationModel(int id, string name, int price, int modelId) : base(id)
        {
            Name = name;
            Price = price;
            ModelId = modelId;
        }
    }
}
