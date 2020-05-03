using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car
{
    public class CarEngine : BaseModel
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public CarEngineType Type { get; set; }
    }
}
