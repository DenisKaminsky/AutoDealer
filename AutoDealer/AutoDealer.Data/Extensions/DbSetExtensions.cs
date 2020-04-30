using System.Linq;
using AutoDealer.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> IncludeRange<T>(this IQueryable<T> set, string[] properties) where T : BaseModel
        {
            set = properties.Aggregate(set, (current, propertyPath) => current.Include(propertyPath));

            return set;
        }
    }
}
