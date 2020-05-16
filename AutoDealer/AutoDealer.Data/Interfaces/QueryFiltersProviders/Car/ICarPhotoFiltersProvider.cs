using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Car
{
    public interface ICarPhotoFiltersProvider : IBaseFiltersProvider<CarPhoto>
    {
        Expression<Func<CarPhoto, bool>> ByModelColorBodyTypeId(int modelId, int bodyTypeId, int colorId);
    }
}
