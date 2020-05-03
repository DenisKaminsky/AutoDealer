using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface ICarEngineTypeQueryFiltersProvider : IBaseFiltersProvider<CarEngineType>
    {
        Expression<Func<CarEngineType, bool>> ByName(string name);
    }
}
