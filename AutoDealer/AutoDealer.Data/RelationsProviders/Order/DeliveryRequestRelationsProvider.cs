using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Order;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Order
{
    public class DeliveryRequestRelationsProvider : BaseRelationsProvider, IDeliveryRequestRelationsProvider
    {
        public string[] JoinDeliveryRequestInfo { get; } =
        {
            $"{nameof(DeliveryRequest.Car)}.{nameof(CarStock.Model)}.{nameof(CarModel.Brand)}",
            $"{nameof(DeliveryRequest.Manager)}",
            $"{nameof(DeliveryRequest.SupplierManager)}",
            $"{nameof(DeliveryRequest.Status)}"
        };

        public string[] JoinInfoForPromotion { get; } =
        {
            $"{nameof(DeliveryRequest.Order)}",
            $"{nameof(DeliveryRequest.Car)}"
        };
    }
}
