using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.User
{
    public interface IUserFiltersProvider : IBaseFiltersProvider<Models.User.User>
    {
        Expression<Func<Models.User.User, bool>> ByEmail(string email);
    }
}
