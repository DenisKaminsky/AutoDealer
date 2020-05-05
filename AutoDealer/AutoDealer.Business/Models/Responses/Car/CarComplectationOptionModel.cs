namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarComplectationOptionModel : BaseModel
    {
        public string Name { get; }

        public CarComplectationOptionModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
