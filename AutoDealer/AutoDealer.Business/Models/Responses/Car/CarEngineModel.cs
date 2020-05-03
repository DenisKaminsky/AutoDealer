namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarEngineModel : BaseModel
    {
        public string Name { get; }
        public int Volume { get; }
        public int Power { get; }
        public CarEngineTypeModel Type { get; }

        public CarEngineModel(int id, string name, int volume, int power, CarEngineTypeModel type) : base(id)
        {
            Name = name;
            Volume = volume;
            Power = power;
            Type = type;
        }
    }
}
