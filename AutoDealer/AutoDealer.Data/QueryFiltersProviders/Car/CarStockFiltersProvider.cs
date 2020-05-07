using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarStockFiltersProvider : BaseFiltersProvider<CarStock>, ICarStockFiltersProvider
    {
        public Expression<Func<CarStock, bool>> InStock()
        {
            return item => item.Amount > 0;
        }

        public Expression<Func<CarStock, bool>> MatchAll(int modelId, int bodyTypeId, int colorId, int engineGearboxId, int complectationId )
        {
            return item => item.ModelId == modelId && item.BodyTypeId == bodyTypeId && item.ColorId == colorId 
                           && item.EngineGearboxId == engineGearboxId && item.ComplectationId == complectationId;
        }

        public Expression<Func<CarStock, bool>> InStockById(int id)
        {
            return item => item.Id == id && item.Amount > 0;
        }
    }
}
