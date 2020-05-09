using System;
using System.Linq;
using System.Security.Claims;
using AutoDealer.Miscellaneous.Enums;

namespace AutoDealer.Web.Extensions
{
    public static class CheckPermissionsExtensions
    {
        public static bool CanCompleteWorkOrder(int originalUserId, ClaimsPrincipal user, params UserRoles[] rolesWithNoVerifying)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            var claimId = Convert.ToInt32(user.Claims.First(c => c.Type == "Id").Value);
            var claimRole = user.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            var role = (UserRoles)Enum.Parse(typeof(UserRoles), claimRole);
            return claimId == originalUserId || rolesWithNoVerifying.Contains(role);
        }

    }
}
