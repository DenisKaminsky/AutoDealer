namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarEngineTypeModel : BaseModel
    {
        public string Name { get; }

        public CarEngineTypeModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
