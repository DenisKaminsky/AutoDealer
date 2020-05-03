using System.Collections.Generic;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class ColorCode : BaseModel
    {
        public string Name { get; set; }
        
        public string HexValue { get; set; }

        public IEnumerable<ModelSupportsColor> SupportedModels { get; set; }
    }
}
