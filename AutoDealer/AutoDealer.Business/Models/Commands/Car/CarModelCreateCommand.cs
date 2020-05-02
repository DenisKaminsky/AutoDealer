using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarModelCreateCommand : ICreateCommand
    {
        public string Name { get; }
        public int BrandId { get; }
        public int Price { get; }

        public CarModelCreateCommand(string name, int brandId, int price)
        {
            Name = name;
            BrandId = brandId;
            Price = price;
        }
    }
}
