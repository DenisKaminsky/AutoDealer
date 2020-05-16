using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarPhotoFiltersProvider : BaseFiltersProvider<CarPhoto>, ICarPhotoFiltersProvider
    {
        public Expression<Func<CarPhoto, bool>> ByModelColorBodyTypeId(int modelId, int bodyTypeId, int colorId)
        {
            return item => item.ModelId == modelId && item.BodyTypeId == bodyTypeId && item.ColorId == colorId;
        }
    }
}
