using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarModelCarStockModel : BaseModel
    {
        public string Name { get; }
        public BrandModel Brand { get; }

        public CarModelCarStockModel(int id, string name, BrandModel brand) : base(id)
        {
            Name = name;
            Brand = brand;
        }
    }
}
