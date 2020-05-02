using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Interfaces.Repositories
{
    public interface IGenericReadRepository
    {
        Task<T[]> GetAllAsync<T>(params string[] propertiesToInclude) where T : BaseModel;

        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel;

        Task<T[]> GetAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel;

        bool ValidateExists<T>(Expression<Func<T, bool>> filter) where T : BaseModel;

        Task<int[]> GetAllIdsAsync<T>() where T : BaseModel;
    }
}
