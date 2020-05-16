using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Order
{
    public class OrderFiltersProvider : BaseFiltersProvider<Models.Order.Order>, IOrderFiltersProvider
    {
        public Expression<Func<Models.Order.Order, bool>> ByManagerId(int id)
        {
            return item => item.ManagerId == id;
        }

        public Expression<Func<Models.Order.Order, bool>> ByClientId(int id)
        {
            return item => item.ClientId == id;
        }

        public Expression<Func<Models.Order.Order, bool>> ByStatusId(int id)
        {
            return item => item.StatusId == id;
        }
    }
}
