using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarComplectationCreateCommand : ICreateCommand
    {
        public string Name { get; }
        public int Price { get; }
        public int ModelId { get; }

        public CarComplectationCreateCommand(string name, int price, int modelId)
        {
            Name = name;
            Price = price;
            ModelId = modelId;
        }
    }
}
