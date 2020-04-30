using System;
using System.Linq.Expressions;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.Base
{
    public interface IBaseFiltersProvider<T>where T : BaseModel
    {
        Expression<Func<T, bool>> ById(int id);
    }
}
