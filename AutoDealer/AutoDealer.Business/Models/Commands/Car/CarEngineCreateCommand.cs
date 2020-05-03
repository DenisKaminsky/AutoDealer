using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarEngineCreateCommand : ICreateCommand
    {
        public string Name { get; }
        public float Volume { get; }
        public int Power { get; }
        public int TypeId { get; }

        public CarEngineCreateCommand(string name, float volume, int power, int typeId)
        {
            Name = name;
            Volume = volume;
            Power = power;
            TypeId = typeId;
        }
    }
}
