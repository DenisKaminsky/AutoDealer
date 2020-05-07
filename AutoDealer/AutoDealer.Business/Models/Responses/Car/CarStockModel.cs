using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Models.Responses.Car
{
    public class CarStockModel : BaseModel
    {
        public CarModelCarStockModel Model { get; set; }
        public CarBodyTypeModel BodyType { get; }
        public ColorCodeModel Color { get; }
        public CarEngineModel Engine { get; }
        public GearboxModel Gearbox { get; }
        public CarComplectationCarStockModel Complectation { get; }
        public int Amount { get; }
        public int Price { get; }

        public CarStockModel(int id, CarBodyTypeModel bodyType, ColorCodeModel color, CarComplectationCarStockModel complectation, int amount, int price, CarEngineModel engine, GearboxModel gearbox) : base(id)
        {
            BodyType = bodyType;
            Color = color;
            Complectation = complectation;
            Amount = amount;
            Price = price;
            Engine = engine;
            Gearbox = gearbox;
        }
    }
}
