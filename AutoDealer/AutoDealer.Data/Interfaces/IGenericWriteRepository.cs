using System.Threading.Tasks;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Interfaces
{
    public interface IGenericWriteRepository
    {
        Task AddAsync<T>(T model) where T : BaseModel;

        Task AddRangeAsync<T>(params T[] models) where T : BaseModel;

        Task RemoveByIdAsync<T>(int id) where T : BaseModel;
        
        Task RemoveRangeAsync<T>(params T[] items) where T : BaseModel;

        Task UpdateAsync<T>(T model) where T : BaseModel;
    }
}
