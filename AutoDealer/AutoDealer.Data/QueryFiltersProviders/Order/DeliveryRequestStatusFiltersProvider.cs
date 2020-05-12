using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Models.Order;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Order
{
    public class DeliveryRequestStatusFiltersProvider : BaseFiltersProvider<DeliveryRequestStatus>, IDeliveryRequestStatusFiltersProvider
    {
    }
}
