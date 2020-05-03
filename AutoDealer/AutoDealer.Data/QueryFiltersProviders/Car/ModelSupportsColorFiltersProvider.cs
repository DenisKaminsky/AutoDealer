using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class ModelSupportsColorFiltersProvider : BaseFiltersProvider<ModelSupportsColor>, IModelSupportsColorFiltersProvider
    {
        public Expression<Func<ModelSupportsColor, bool>> ByModelId(int id)
        {
            return item => item.ModelId == id;
        }

        public Expression<Func<ModelSupportsColor, bool>> ByColorId(int id)
        {
            return item => item.ColorId == id;
        }

        public Expression<Func<ModelSupportsColor, bool>> ByModelIdAndColorId(int modelId, int colorId)
        {
            return item => item.ModelId == modelId && item.ColorId == colorId;
        }
    }
}
