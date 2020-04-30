using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class Country : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
    }
}
