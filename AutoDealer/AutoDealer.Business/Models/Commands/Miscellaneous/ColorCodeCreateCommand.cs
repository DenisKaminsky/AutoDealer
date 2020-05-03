using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class ColorCodeCreateCommand : ICreateCommand
    {
        public string Name { get; }

        public string HexValue { get; }

        public ColorCodeCreateCommand(string name, string hexValue)
        {
            Name = name;
            HexValue = hexValue;
        }
    }
}
