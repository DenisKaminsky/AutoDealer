using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarComplectationOptionFiltersProvider : BaseFiltersProvider<CarComplectationOption>, ICarComplectationOptionFiltersProvider
    {
        public Expression<Func<CarComplectationOption, bool>> ByComplectationId(int id)
        {
            return item => item.ComplectationId == id;
        }
    }
}
