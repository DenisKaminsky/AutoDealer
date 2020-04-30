﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.Extensions;
using AutoDealer.Data.Interfaces;
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
