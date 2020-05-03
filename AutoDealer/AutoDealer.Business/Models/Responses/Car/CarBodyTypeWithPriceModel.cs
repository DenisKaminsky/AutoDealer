namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarBodyTypeWithPriceModel : CarBodyTypeModel
    {
        public int ModelId { get; }
        public int Price { get; }

        public CarBodyTypeWithPriceModel(int id, string name, int modelId, int price) : base(id, name)
        {
            ModelId = modelId;
            Price = price;
        }
    }
}
