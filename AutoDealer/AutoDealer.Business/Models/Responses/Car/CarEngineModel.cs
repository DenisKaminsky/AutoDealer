namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarEngineModel : BaseModel
    {
        public string Name { get; }
        public int Volume { get; }
        public int Power { get; }
        public int Price { get; }
        public CarEngineTypeModel Type { get; }

        public CarEngineModel(int id, string name, int volume, int power, int price, CarEngineTypeModel type) : base(id)
        {
            Name = name;
            Volume = volume;
            Power = power;
            Price = price;
            Type = type;
        }
    }
}
