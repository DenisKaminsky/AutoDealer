using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Car
{
    public class EngineSupportsGearboxRelationsProvider : BaseRelationsProvider, IEngineSupportsGearboxRelationsProvider
    {
        public string[] JoinGearboxAndEngine { get; } =
        {
            nameof(EngineSupportsGearbox.Gearbox),
            $"{nameof(EngineSupportsGearbox.Engine)}.{nameof(CarEngine.Type)}"
        };
    }
}
