namespace AutoDealer.Business.Models.Responses.Miscellaneous
{
    public class ColorCodeModel :BaseModel
    {
        public string Name { get; }

        public string HexValue { get; }

        public ColorCodeModel(int id, string name, string hexValue) : base(id)
        {
            Name = name;
            HexValue = hexValue;
        }
    }
}
