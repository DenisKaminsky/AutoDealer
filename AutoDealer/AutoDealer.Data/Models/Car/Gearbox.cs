using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Models.Car
{
    public class Gearbox : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<EngineSupportsGearbox> SupportedEngines { get; set; }
    }
}
