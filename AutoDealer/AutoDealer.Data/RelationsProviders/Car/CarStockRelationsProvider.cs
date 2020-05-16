using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Car
{
    public class CarStockRelationsProvider : BaseRelationsProvider, ICarStockRelationsProvider
    {
        public string[] JoinAll { get; } =
        {
            $"{nameof(CarStock.Model)}.{nameof(CarModel.Brand)}.{nameof(Brand.Country)}",
            $"{nameof(CarStock.BodyType)}",
            $"{nameof(CarStock.Color)}",
            $"{nameof(CarStock.Complectation)}",
            $"{nameof(CarStock.EngineGearbox)}.{nameof(EngineSupportsGearbox.Gearbox)}",
            $"{nameof(CarStock.EngineGearbox)}.{nameof(EngineSupportsGearbox.Engine)}.{nameof(CarEngine.Type)}"
        };
    }
}
