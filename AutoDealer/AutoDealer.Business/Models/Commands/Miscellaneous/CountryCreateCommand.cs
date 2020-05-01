namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class CountryCreateCommand
    {
        public string Name { get; }

        public CountryCreateCommand(string name)
        {
            Name = name;
        }
    }
}
