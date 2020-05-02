namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarModelUpdateCommand : BaseModel
    {
        public string Name { get; }
        public int BrandId { get; }
        public int Price { get; }

        public CarModelUpdateCommand(int id, string name, int brandId, int price) : base(id)
        {
            Name = name;
            BrandId = brandId;
            Price = price;
        }
    }
}
