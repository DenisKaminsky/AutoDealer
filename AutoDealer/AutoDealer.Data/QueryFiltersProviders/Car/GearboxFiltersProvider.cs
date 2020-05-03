using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class GearboxFiltersProvider : BaseFiltersProvider<Gearbox>, IGearboxFiltersProvider
    {
        public Expression<Func<Gearbox, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name);
        }
    }
}
