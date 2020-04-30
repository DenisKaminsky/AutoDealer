using System;
using System.Linq;
using AutoDealer.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> IncludeRange<T>(this IQueryable<T> set, string[] properties) where T : BaseModel
        {
            foreach (var item in properties ?? Array.Empty<string>())
            {
                set.Include(item);
            }

            return set;
        }
    }
}
