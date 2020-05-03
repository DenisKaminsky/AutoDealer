using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarEngineUpdateCommand : BaseModel, IUpdateCommand
    {
        public string Name { get; }
        public int Volume { get; }
        public int Power { get; }
        public int TypeId { get; }

        public CarEngineUpdateCommand(int id, string name, int volume, int power, int typeId) : base(id)
        {
            Name = name;
            Volume = volume;
            Power = power;
            TypeId = typeId;
        }
    }
}
