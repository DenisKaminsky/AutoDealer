using AutoDealer.Data.Models.Base;
using System.Collections.Generic;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class Supplier : BaseModel
    {
        public string CompanyName { get; set; }

        public string Ein { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        
        public Brand Brand { get; set; }

        public IEnumerable<SupplierPhoto> Photos { get; set; }
    }
}
