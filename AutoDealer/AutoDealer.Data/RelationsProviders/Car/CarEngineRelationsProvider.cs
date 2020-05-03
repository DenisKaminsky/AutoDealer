using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Car
{
    public class CarEngineRelationsProvider : BaseRelationsProvider, ICarEngineRelationsProvider
    {
        public string[] JoinEngineType { get; } = { nameof(CarEngine.Type) };
    }
}
