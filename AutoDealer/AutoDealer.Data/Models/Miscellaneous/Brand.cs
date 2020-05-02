using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
        
        public int? SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
