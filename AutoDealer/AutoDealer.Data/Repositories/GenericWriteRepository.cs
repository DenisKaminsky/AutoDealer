using System.Threading.Tasks;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Repositories
{
    public class GenericWriteRepository : BaseRepository, IGenericWriteRepository
    {
        public GenericWriteRepository(DataContext dataContext) : base(dataContext) { }

        public async Task AddAsync<T>(T model) where T : BaseModel
        {
            await DbContext.Set<T>().AddAsync(model);
        }

        public async Task AddRangeAsync<T>(params T[] models) where T : BaseModel
        {
            await DbContext.Set<T>().AddRangeAsync(models);
        }

        public async Task<bool> RemoveByIdAsync<T>(int id) where T : BaseModel
        {
            var model = await DbContext.Set<T>().FirstOrDefaultAsync(item => item.Id == id);

            if (model == null)
                return false;

            DbContext.Set<T>().Remove(model);
            return true;
        }

        public Task RemoveRangeAsync<T>(params T[] items) where T : BaseModel
        {
            DbContext.Set<T>().RemoveRange(items);
            return Task.CompletedTask;
        }

        public Task UpdateAsync<T>(T model) where T : BaseModel
        {
            DbContext.Set<T>().Update(model);
            return Task.CompletedTask;
        }
    }
}
