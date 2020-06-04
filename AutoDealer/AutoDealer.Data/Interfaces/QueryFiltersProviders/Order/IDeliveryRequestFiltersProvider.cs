using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Order;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Order
{
    public interface IDeliveryRequestFiltersProvider : IBaseFiltersProvider<DeliveryRequest>
    {
        Expression<Func<DeliveryRequest, bool>> ByManagerId(int id);
        Expression<Func<DeliveryRequest, bool>> BySupplierManagerId(int id);
        Expression<Func<DeliveryRequest, bool>> ByStatusId(int id);
        Expression<Func<DeliveryRequest, bool>> ByIdAndStatus(int id, int statusId);
    }
}
