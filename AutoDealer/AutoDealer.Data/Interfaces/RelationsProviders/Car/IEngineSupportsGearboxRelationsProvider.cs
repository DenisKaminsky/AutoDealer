namespace AutoDealer.Data.Interfaces.RelationsProviders.Car
{
    public interface IEngineSupportsGearboxRelationsProvider
    {
        string[] JoinGearboxAndEngine { get; }
    }
}
