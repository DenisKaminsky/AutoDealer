using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Models.Car.Relations
{
    public class ModelSupportsColor : BaseModel
    {
        public int ModelId { get; set; }
        public CarModel Model { get; set; }

        public int ColorId { get; set; }
        public ColorCode Color { get; set; }
    }
}
