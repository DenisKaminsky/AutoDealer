using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Models.Car
{
    public class CarStock : BaseModel
    {
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        public int BodyTypeId { get; set; }
        public CarBodyType BodyType { get; set; }
        public int ColorId { get; set; }
        public ColorCode Color { get; set; }
        public int EngineGearboxId { get; set; }
        public EngineSupportsGearbox EngineGearbox { get; set; }
        public int ComplectationId { get; set; }
        public CarComplectation Complectation { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
