using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface ICarStockFiltersProvider : IBaseFiltersProvider<CarStock>
    {
        Expression<Func<CarStock, bool>> InStock();
        Expression<Func<CarStock, bool>> MatchAll(int modelId, int bodyTypeId, int colorId, int engineGearboxId,int complectationId);
        Expression<Func<CarStock, bool>> InStockById(int id);
    }
}
