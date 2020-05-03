using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class ColorCode : BaseModel
    {
        public string Name { get; set; }
        
        public string HexValue { get; set; }
    }
}
