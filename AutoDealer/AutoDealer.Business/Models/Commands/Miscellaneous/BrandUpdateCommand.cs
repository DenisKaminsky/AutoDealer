namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class BrandUpdateCommand : BaseModel
    {
        public string Name { get; }

        public int CountryId { get; }

        public BrandUpdateCommand(int id, string name, int countryId) : base(id)
        {
            Name = name;
            CountryId = countryId;
        }
    }
}
