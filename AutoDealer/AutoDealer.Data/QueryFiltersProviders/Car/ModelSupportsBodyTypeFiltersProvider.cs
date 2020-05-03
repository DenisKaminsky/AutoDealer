using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class ModelSupportsBodyTypeFiltersProvider: BaseFiltersProvider<ModelSupportsBodyType>, IModelSupportsBodyTypeFiltersProvider
    {
        public Expression<Func<ModelSupportsBodyType, bool>> ByModelId(int id)
        {
            return item => item.ModelId == id;
        }

        public Expression<Func<ModelSupportsBodyType, bool>> ByBodyTypeId(int id)
        {
            return item => item.BodyTypeId == id;
        }

        public Expression<Func<ModelSupportsBodyType, bool>> ByModelIdAndBodyTypeId(int modelId, int bodyTypeId)
        {
            return item => item.ModelId == modelId && item.BodyTypeId == bodyTypeId;
        }
    }
}
