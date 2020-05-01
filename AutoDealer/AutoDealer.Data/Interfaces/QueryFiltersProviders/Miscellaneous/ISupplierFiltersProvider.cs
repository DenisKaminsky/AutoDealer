using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous
{
    public interface ISupplierFiltersProvider : IBaseFiltersProvider<Supplier>
    {
        Expression<Func<Supplier, bool>> ByBrandId(int id);
    }
}
