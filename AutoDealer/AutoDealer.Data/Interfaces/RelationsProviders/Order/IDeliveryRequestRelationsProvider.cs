namespace AutoDealer.Data.Interfaces.RelationsProviders.Order
{
    public interface IDeliveryRequestRelationsProvider
    {
        string[] JoinDeliveryRequestInfo { get; }
        string[] JoinInfoForPromotion { get; }
    }
}
