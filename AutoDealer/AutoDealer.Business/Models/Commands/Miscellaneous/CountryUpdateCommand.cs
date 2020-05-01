namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class CountryUpdateCommand : BaseModel
    {
        public string Name { get; }

        public CountryUpdateCommand(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
