using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.User
{
    public class UserFiltersProvider : BaseFiltersProvider<Models.User.User>, IUserFiltersProvider
    {
        public Expression<Func<Models.User.User, bool>> ByEmail(string email)
        {
            return item => EF.Functions.ILike(item.Email, email);
        }
    }
}
