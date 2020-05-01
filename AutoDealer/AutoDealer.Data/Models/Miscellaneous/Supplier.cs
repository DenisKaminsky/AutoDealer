using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class Supplier : BaseModel
    {
        public string CompanyName { get; set; }

        public string Ein { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}
