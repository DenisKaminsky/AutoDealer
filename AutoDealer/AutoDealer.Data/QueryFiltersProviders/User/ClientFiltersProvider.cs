using System;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Models.User;
using AutoDealer.Data.QueryFiltersProviders.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.QueryFiltersProviders.User
{
    public class ClientFiltersProvider : BaseFiltersProvider<Client>, IClientFiltersProvider
    {
        public Expression<Func<Client, bool>> ByPassportId(string passportId)
        {
            return item => EF.Functions.ILike(item.Email, passportId);
        }

        public Expression<Func<Client, bool>> OthersWithPassportId(int id, string passportId)
        {
            return item => item.Id != id && EF.Functions.ILike(item.Email, passportId);
        }
    }
}
