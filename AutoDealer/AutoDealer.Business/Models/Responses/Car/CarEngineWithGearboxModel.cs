namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarEngineWithGearboxModel : BaseModel
    {
        public int ModelId { get; }
        public CarEngineModel Engine { get; }
        public GearboxModel Gearbox { get; }
        public int Price { get; }

        public CarEngineWithGearboxModel(int id, int modelId, CarEngineModel engine, GearboxModel gearbox, int price) : base(id)
        {
            ModelId = modelId;
            Engine = engine;
            Gearbox = gearbox;
            Price = price;
        }
    }
}
