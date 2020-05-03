using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Car
{
    public class CarEngineType : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<CarEngine> SupportedEngines { get; set; }
    }
}
