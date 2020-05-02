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
    public class GenericReadRepository : BaseGenericRepository, IGenericReadRepository
    {
        public GenericReadRepository(DataContext context) : base(context) { }
        
        public Task<T[]> GetAllAsync<T>(params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .AsNoTracking()
                .ToArrayAsync();
        }
        
        public Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);
        }
        
        public bool ValidateExists<T>(Expression<Func<T, bool>> filter) where T : BaseModel
        {
            return DbContext.Set<T>()
                .Any(filter);
        }

        public Task<int[]> GetAllIdsAsync<T>() where T : BaseModel
        {
            return DbContext.Set<T>()
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public Task<T[]> GetAsync<T>(Expression<Func<T, bool>> filter, params string[] propertiesToInclude) where T : BaseModel
        {
            return DbContext.Set<T>()
                .IncludeRange(propertiesToInclude)
                .Where(filter)
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}
