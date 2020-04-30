using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous
{
    public interface IBrandFiltersProvider : IBaseFiltersProvider<Brand>
    {
        Expression<Func<Brand, bool>> ByCountryId(int id);
    }
}
