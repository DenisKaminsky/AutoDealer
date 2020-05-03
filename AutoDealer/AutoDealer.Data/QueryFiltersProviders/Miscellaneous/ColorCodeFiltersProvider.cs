using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Miscellaneous
{
    public class ColorCodeFiltersProvider : BaseFiltersProvider<ColorCode>, IColorCodeFiltersProvider
    {
        public Expression<Func<ColorCode, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name);
        }
    }
}
