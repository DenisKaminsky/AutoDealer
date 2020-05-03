using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarEngineTypeCreateCommand : ICreateCommand
    {
        public string Name { get; }

        public CarEngineTypeCreateCommand(string name)
        {
            Name = name;
        }
    }
}
