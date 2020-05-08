using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.User;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.User
{
    public interface IClientFiltersProvider : IBaseFiltersProvider<Client>
    {
        Expression<Func<Client, bool>> ByPassportId(string passportId);
        Expression<Func<Client, bool>> OthersWithPassportId(int id, string passportId);
    }
}
