using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Models.Car
{
    public class CarBodyType : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<ModelSupportsBodyType> SupportedModels { get; set; }
    }
}
