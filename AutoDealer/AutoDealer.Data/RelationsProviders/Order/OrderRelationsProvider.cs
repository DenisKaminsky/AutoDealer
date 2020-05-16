using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Order
{
    public class OrderRelationsProvider : BaseRelationsProvider, IOrderRelationsProvider
    {
        public string[] JoinOrderInfo { get; } =
        {
            $"{nameof(Models.Order.Order.Manager)}",
            $"{nameof(Models.Order.Order.Status)}"
        };
    }
}
