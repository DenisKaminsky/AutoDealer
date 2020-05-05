using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface ICarComplectationFiltersProvider : IBaseFiltersProvider<CarComplectation>
    {
        Expression<Func<CarComplectation, bool>> ByModelId(int id);

        Expression<Func<CarComplectation, bool>> ByName(string name);
    }
}
