using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car
{
    public class CarPhoto : BaseModel
    {
        public int CarId { get; set; }
        public CarStock Car { get; set; }
        public string FileName { get; set; }
    }
}
