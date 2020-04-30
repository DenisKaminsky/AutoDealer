using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Miscellaneous
{
    public class BrandFiltersProvider : BaseFiltersProvider<Brand>, IBrandFiltersProvider
    {
        public Expression<Func<Brand, bool>> ByCountryId(int id)
        {
            return item => item.CountryId == id;
        }
    }
}
