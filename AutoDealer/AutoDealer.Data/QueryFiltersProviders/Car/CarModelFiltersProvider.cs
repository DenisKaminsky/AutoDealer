using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarModelFiltersProvider: BaseFiltersProvider<CarModel>, ICarModelFiltersProvider
    {
        public Expression<Func<CarModel, bool>> ByBrandId(int id)
        {
            return item => item.BrandId == id;
        }
    }
}
