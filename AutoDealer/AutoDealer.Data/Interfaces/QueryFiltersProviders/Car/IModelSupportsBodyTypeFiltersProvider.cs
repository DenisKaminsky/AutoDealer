using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car.Relations;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface IModelSupportsBodyTypeFiltersProvider : IBaseFiltersProvider<ModelSupportsBodyType>
    {
        Expression<Func<ModelSupportsBodyType, bool>> ByModelId(int id);

        Expression<Func<ModelSupportsBodyType, bool>> ByBodyTypeId(int id);

        Expression<Func<ModelSupportsBodyType, bool>> ByModelIdAndBodyTypeId(int modelId, int bodyTypeId);
    }
}
