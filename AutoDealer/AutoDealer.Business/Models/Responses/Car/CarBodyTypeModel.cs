namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarBodyTypeModel : BaseModel
    {
        public string Name { get; }

        public CarBodyTypeModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
