using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarComplectationFiltersProvider : BaseFiltersProvider<CarComplectation>, ICarComplectationFiltersProvider
    {
        public Expression<Func<CarComplectation, bool>> ByModelId(int id)
        {
            return item => item.ModelId == id;
        }

        public Expression<Func<CarComplectation, bool>> ByModelIdAndComplectationId(int modelId, int complectationId)
        {
            return item => item.ModelId == modelId && item.Id == complectationId;
        }

        public Expression<Func<CarComplectation, bool>> ByName(string name)
        {
            return item => EF.Functions.ILike(item.Name, name);
        }
    }
}
