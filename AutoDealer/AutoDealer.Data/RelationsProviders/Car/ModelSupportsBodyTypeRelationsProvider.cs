using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Car
{
    public class ModelSupportsBodyTypeRelationsProvider : BaseRelationsProvider, IModelSupportsBodyTypeRelationsProvider
    {
        public string[] JoinBodyType { get; } = { nameof(ModelSupportsBodyType.BodyType) };
    }
}
