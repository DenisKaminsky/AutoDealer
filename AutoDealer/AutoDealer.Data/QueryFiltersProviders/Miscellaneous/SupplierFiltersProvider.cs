using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Miscellaneous
{
    public class SupplierFiltersProvider : BaseFiltersProvider<Supplier>, ISupplierFiltersProvider
    {
        public Expression<Func<Supplier, bool>> ByBrandId(int id)
        {
            return item => item.BrandId == id;
        }
    }
}
