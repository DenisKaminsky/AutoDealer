using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.User
{
    public interface IUserFiltersProvider : IBaseFiltersProvider<Models.User.User>
    {
        Expression<Func<Models.User.User, bool>> Active();
        Expression<Func<Models.User.User, bool>> ActiveById(int id);
        Expression<Func<Models.User.User, bool>> ByEmail(string email);
        Expression<Func<Models.User.User, bool>> ActiveByEmail(string email);
        Expression<Func<Models.User.User, bool>> ActiveByIdAndRoleId(int id, int roleId);
    }
}
