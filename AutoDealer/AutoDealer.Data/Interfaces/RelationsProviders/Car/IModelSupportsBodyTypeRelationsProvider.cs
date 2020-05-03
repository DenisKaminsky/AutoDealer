namespace AutoDealer.Data.Interfaces.RelationsProviders.Car
{
    public interface IModelSupportsBodyTypeRelationsProvider
    {
        string[] JoinBodyType { get; }
    }
}
