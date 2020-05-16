using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Models.Car
{
    public class CarPhoto : BaseModel
    {
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        public int BodyTypeId { get; set; }
        public CarBodyType BodyType { get; set; }
        public int ColorId { get; set; }
        public ColorCode Color { get; set; }
        public string FileName { get; set; }
    }
}
