using AutoDealer.Data.Interfaces.RelationsProviders.User;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.User
{
    public class UserRelationsProvider : BaseRelationsProvider, IUserRelationsProvider
    {
        public string[] JoinRole { get; } = { nameof(Models.User.User.Role) };
    }
}
