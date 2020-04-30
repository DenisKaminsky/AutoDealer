using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
