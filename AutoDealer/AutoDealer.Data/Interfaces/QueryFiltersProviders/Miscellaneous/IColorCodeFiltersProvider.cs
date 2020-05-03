using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous
{
    public interface IColorCodeFiltersProvider : IBaseFiltersProvider<ColorCode>
    {
        Expression<Func<ColorCode, bool>> ByName(string name);
    }
}
