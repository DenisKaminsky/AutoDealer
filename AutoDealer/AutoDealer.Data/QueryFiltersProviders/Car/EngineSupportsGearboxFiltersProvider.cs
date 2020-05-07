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

        public Expression<Func<EngineSupportsGearbox, bool>> ByModelEngineGearbox(int modelId, int engineGearboxId)
        {
            return item => item.ModelId == modelId && item.Id == engineGearboxId;
        }

        public Expression<Func<EngineSupportsGearbox, bool>> ByModelEngineGearbox(int modelId, int engineId, int gearboxId)
        {
            return item => item.ModelId == modelId && item.EngineId == engineId && item.GearboxId == gearboxId;
        }
    }
}
