namespace AutoDealer.Data.Interfaces.RelationsProviders.Order
{
    public interface IOrderRelationsProvider
    {
        string[] JoinOrderDetails { get; }
        string[] JoinDeliveryRequest { get; }
    }
}
