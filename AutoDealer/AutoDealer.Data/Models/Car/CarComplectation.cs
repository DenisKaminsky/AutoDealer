using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car
{
    public class CarComplectation : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        public IEnumerable<CarComplectationOption> Options { get; set; }
        public IEnumerable<CarStock> CarsInStock { get; set; }
    }
}
