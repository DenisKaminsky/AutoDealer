using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Business.Models.Responses.Miscellaneous
{
    public class BrandModel : BaseModel
    {
        public string Name { get; }
        
        public CountryModel Country { get; }

        public BrandModel(int id, string name, CountryModel country) : base(id)
        {
            Name = name;
            Country = country;
        }
    }
}
