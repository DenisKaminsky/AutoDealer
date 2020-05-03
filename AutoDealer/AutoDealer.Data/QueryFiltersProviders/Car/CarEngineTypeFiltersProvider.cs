using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarEngineTypeFiltersProvider : BaseFiltersProvider<CarEngineType>, ICarEngineTypeFiltersProvider
    {
        public Expression<Func<CarEngineType, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name);
        }
    }
}
