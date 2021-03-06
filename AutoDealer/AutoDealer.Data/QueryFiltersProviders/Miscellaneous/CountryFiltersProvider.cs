﻿using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Miscellaneous
{
    public class CountryFiltersProvider : BaseFiltersProvider<Country>, ICountryFiltersProvider
    {
        public Expression<Func<Country, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name); ;
        }

        public Expression<Func<Country, bool>> OthersWithName(int id, string name)
        {
            return item => (item.Id != id) && (EF.Functions.ILike(item.Name, name)); ;
        }
    }
}
