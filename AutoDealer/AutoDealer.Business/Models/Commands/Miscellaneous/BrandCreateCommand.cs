namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class BrandCreateCommand
    {
        public string Name { get; }

        public int CountryId { get; }

        public BrandCreateCommand(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }
    }
}
