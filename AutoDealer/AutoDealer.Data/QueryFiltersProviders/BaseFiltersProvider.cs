using System;
using System.Linq.Expressions;
using AutoDealer.Data.Models.BaseModels;

namespace AutoDealer.Data.QueryFiltersProviders
{
    public abstract class BaseFiltersProvider<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> ById(int id)
        {
            return item => item.Id == id;
        }
    }
}
