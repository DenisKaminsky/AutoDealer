using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Order
{
    public interface IOrderFiltersProvider : IBaseFiltersProvider<Models.Order.Order>
    {
        Expression<Func<Models.Order.Order, bool>> ByManagerId(int id);
        Expression<Func<Models.Order.Order, bool>> ByClientId(int id);
        Expression<Func<Models.Order.Order, bool>> ByStatusId(int id);
    }
}
