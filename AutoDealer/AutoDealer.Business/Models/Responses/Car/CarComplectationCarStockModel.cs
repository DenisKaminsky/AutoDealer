namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarComplectationCarStockModel : BaseModel
    {
        public string Name { get; }

        public CarComplectationCarStockModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
