using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class GearboxCreateCommand : ICreateCommand
    {
        public string Name { get; }

        public GearboxCreateCommand(string name)
        {
            Name = name;
        }
    }
}
