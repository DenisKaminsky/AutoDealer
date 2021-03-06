﻿using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous
{
    public interface ICountryFiltersProvider : IBaseFiltersProvider<Country>
    {
        Expression<Func<Country, bool>> ByName(string name);
        Expression<Func<Country, bool>> OthersWithName(int id, string name);
    }
}
