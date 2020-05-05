using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car
{
    public class CarComplectationOption : BaseModel
    {
        public string Name { get; set; }
        public int ComplectationId { get; set; }
        public CarComplectation Complectation { get; set; }
    }
}
