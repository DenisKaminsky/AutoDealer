using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface IGearboxFiltersProvider : IBaseFiltersProvider<Gearbox>
    {
        Expression<Func<Gearbox, bool>> ByName(string name);
    }
}
