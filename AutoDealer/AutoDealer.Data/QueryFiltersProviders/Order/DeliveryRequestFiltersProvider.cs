using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Models.Order;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Order
{
    public class DeliveryRequestFiltersProvider : BaseFiltersProvider<DeliveryRequest>, IDeliveryRequestFiltersProvider
    {
        public Expression<Func<DeliveryRequest, bool>> ByManagerId(int id)
        {
            return item => item.ManagerId == id;
        }

        public Expression<Func<DeliveryRequest, bool>> BySupplierManagerId(int id)
        {
            return item => item.SupplierManagerId == id;
        }

        public Expression<Func<DeliveryRequest, bool>> ByStatusId(int id)
        {
            return item => item.StatusId == id;
        }

        public Expression<Func<DeliveryRequest, bool>> ByIdAndStatus(int id, int statusId)
        {
            return item => item.Id == id && item.StatusId == id;
        }
    }
}
