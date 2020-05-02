using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class BrandCreateCommand : ICreateCommand
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
