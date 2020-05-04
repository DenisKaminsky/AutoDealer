using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car.Relations
{
    public class EngineSupportsGearbox : BaseModel
    {
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        public int EngineId { get; set; }
        public CarEngine Engine { get; set; }
        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; }
        public int Price { get; set; }
    }
}
