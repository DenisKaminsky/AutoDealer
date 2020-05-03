namespace AutoDealer.Business.Models.Responses.Car
{
    public class GearboxModel : BaseModel
    {
        public string Name { get; }

        public GearboxModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
