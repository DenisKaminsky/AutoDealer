using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class CountryCreateCommand : ICreateCommand
    {
        public string Name { get; }

        public CountryCreateCommand(string name)
        {
            Name = name;
        }
    }
}
