using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Miscellaneous
{
    public class BrandFiltersProvider : BaseFiltersProvider<Brand>, IBrandFiltersProvider
    {
        public Expression<Func<Brand, bool>> ByCountryId(int id)
        {
            return item => item.CountryId == id;
        }

        public Expression<Func<Brand, bool>> WithSupplier()
        {
            return item => item.SupplierId != null;
        }

        public Expression<Func<Brand, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name);
        }

        public Expression<Func<Brand, bool>> OthersWithName(int id, string name)
        {
            return item => (item.Id != id) && (EF.Functions.ILike(item.Name, name));
        }
    }
}
