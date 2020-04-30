namespace AutoDealer.Business.Models.Responses.Miscellaneous
{
    public class CountryModel : BaseModel
    {
        public string Name { get; }

        public CountryModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
