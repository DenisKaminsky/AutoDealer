namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarModelModel : BaseModel
    {
        public string Name { get; }
        public int BrandId { get; }
        public int Price { get; }

        public CarModelModel(int id, string name, int brandId, int price) : base(id)
        {
            Name = name;
            BrandId = brandId;
            Price = price;
        }
    }
}
