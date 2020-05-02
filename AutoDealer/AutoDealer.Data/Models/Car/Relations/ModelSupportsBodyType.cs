using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car.Relations
{
    public class ModelSupportsBodyType : BaseModel
    {
        public int BodyTypeId { get; set; }
        public CarBodyType BodyType { get; set; }
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        public int Price { get; set; }
    }
}
