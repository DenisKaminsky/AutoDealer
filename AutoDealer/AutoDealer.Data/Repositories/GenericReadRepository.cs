using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.Extensions;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Repositories
{
    public class GenericReadRepository : BaseRepository, IGenericReadRepository
    {
        public GenericReadRepository(DataContext context) : base(context) { }
        
        public Task<T[]> GetAllAsync<T>(params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public Task<IQueryable<T>> GetAllQueryableAsync<T>(params string[] propertiesToInclude) where T : BaseModel
        {
            return Task.Run(() => DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .OrderBy(x => x.Id)
                .AsNoTracking());
        }

        public Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);
        }

        public Task<T> GetByIdAsync<T>(int id, params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<T[]> GetAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .Where(filter)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public Task<IQueryable<T>> GetQueryableAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel
        {
            return Task.Run(() => DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .Where(filter)
                .OrderBy(x => x.Id)
                .AsNoTracking());
        }
        
        public bool ValidateExists<T>(Expression<Func<T, bool>> filter) where T : BaseModel
        {
            return DbContext.Set<T>()
                .Any(filter);
        }
    }
}
