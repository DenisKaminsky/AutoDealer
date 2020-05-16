using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Models.Car
{
    public class CarModel : BaseModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int Price { get; set; }
        public IEnumerable<ModelSupportsBodyType> SupportedBodyTypes { get; set; }
        public IEnumerable<ModelSupportsColor> SupportedColors { get; set; }
        public IEnumerable<EngineSupportsGearbox> SupportedEngineGearboxes { get; set; }
        public IEnumerable<CarComplectation> SupportedComplectations { get; set; }
        public IEnumerable<CarStock> CarsInStock { get; set; }
        public IEnumerable<CarPhoto> Photos { get; set; }
    }
}
