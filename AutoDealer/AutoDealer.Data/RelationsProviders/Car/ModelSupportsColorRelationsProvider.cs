using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Car
{
    public class ModelSupportsColorRelationsProvider : BaseRelationsProvider, IModelSupportsColorRelationsProvider
    {
        public string[] JoinColor { get; } = { nameof(ModelSupportsColor.Color) };
    }
}
