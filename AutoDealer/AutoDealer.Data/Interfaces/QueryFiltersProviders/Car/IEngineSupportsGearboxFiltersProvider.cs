using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface IEngineSupportsGearboxFiltersProvider : IBaseFiltersProvider<EngineSupportsGearbox>
    {
        Expression<Func<EngineSupportsGearbox, bool>> ByModelId(int id);
        Expression<Func<EngineSupportsGearbox, bool>> ByModelEngineGearbox(int modelId, int engineGearboxId);
        Expression<Func<EngineSupportsGearbox, bool>> ByModelEngineGearbox(int modelId, int engineId, int gearboxId);
    }
}
