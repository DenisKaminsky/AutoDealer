using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.User
{
    public class UserFiltersProvider : BaseFiltersProvider<Models.User.User>, IUserFiltersProvider
    {
        public Expression<Func<Models.User.User, bool>> Active()
        {
            return item => item.IsActive;
        }

        public Expression<Func<Models.User.User, bool>> ActiveById(int id)
        {
            return item => item.IsActive && item.Id == id;
        }

        public Expression<Func<Models.User.User, bool>> ActiveByEmail(string email)
        {
            return item => item.IsActive && EF.Functions.ILike(item.Email, email);
        }

        public Expression<Func<Models.User.User, bool>> ByEmail(string email)
        {
            return item => EF.Functions.ILike(item.Email, email);
        }
    }
}
