using System;
using System.Linq.Expressions;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface ICarModelBodyColorFiltersProvider
    {
        Expression<Func<ModelSupportsColor, bool>> ByModelId(int id);
        Expression<Func<ModelSupportsColor, bool>> ByColorId(int id);
        Expression<Func<ModelSupportsColor, bool>> ByModelIdAndColorId(int modelId, int colorId);
    }
}
