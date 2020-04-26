using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.Models.BaseModels;

namespace AutoDealer.Data.Interfaces
{
    public interface IGenericReadRepository
    {
        Task<T[]> GetAllAsync<T>(params string[] propertiesToInclude) where T : BaseModel;

        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel;

        Task<T[]> GetAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel;
    }
}
