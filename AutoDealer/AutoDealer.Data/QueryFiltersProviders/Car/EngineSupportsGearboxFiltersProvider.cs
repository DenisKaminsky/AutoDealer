using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class EngineSupportsGearboxFiltersProvider : BaseFiltersProvider<EngineSupportsGearbox>, IEngineSupportsGearboxFiltersProvider
    {
        public Expression<Func<EngineSupportsGearbox, bool>> ByModelId(int id)
        {
            return item => item.ModelId == id;
        }
    }
}
