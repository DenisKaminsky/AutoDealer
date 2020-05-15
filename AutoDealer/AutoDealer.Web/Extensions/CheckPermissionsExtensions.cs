using System;
using System.Linq;
using System.Security.Claims;
using AutoDealer.Miscellaneous.Enums;

namespace AutoDealer.Web.Extensions
{
    public static class CheckPermissionsExtensions
    {
        public static bool UserHasPermissions(int requiredUserId, ClaimsPrincipal currentUser, params UserRoles[] rolesWithNoVerifying)
        {
            if (!currentUser.Identity.IsAuthenticated)
                return false;

            var claimId = Convert.ToInt32(currentUser.Claims.First(c => c.Type == "Id").Value);
            var claimRole = currentUser.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            var role = (UserRoles)Enum.Parse(typeof(UserRoles), claimRole);
            return claimId == requiredUserId || rolesWithNoVerifying.Contains(role);
        }

    }
}
