using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarBodyTypeCreateCommand : ICreateCommand
    {
        public string Name { get; }

        public CarBodyTypeCreateCommand(string name)
        {
            Name = name;
        }
    }
}
