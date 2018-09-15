using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Swapcode.IdentityServer.ForDevs.InMemory
{
    /// <summary>
    /// Contains in memory identity resources configuration.
    /// </summary>
    public static class IdentityResourcesConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            // define your resources here

            // client needs to request the "scope" PermissionGroupIdentityResourceName to get the users "roles"
            // or the ProfilePermissionGroupIdentityResourceName wich also returns profile claims

            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Description = "Users permission groups.",
                    DisplayName = "Permission groups",
                    Name = CustomScopeNames.Permissions,
                    UserClaims = new List<string>
                    {
                        CustomClaimNames.Permission
                    }
                },
                new IdentityResource
                {
                    Description = "Profile and permission groups.",
                    DisplayName = "Profile and PERM",
                    Name = CustomScopeNames.ProfileWithPermissions,
                    UserClaims = new List<string>
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.FamilyName,
                        JwtClaimTypes.GivenName,
                        JwtClaimTypes.MiddleName,
                        JwtClaimTypes.NickName,
                        JwtClaimTypes.PreferredUserName,
                        JwtClaimTypes.Profile,
                        JwtClaimTypes.Picture,
                        JwtClaimTypes.WebSite,
                        JwtClaimTypes.Gender,
                        JwtClaimTypes.BirthDate,
                        JwtClaimTypes.ZoneInfo,
                        JwtClaimTypes.Locale,
                        JwtClaimTypes.UpdatedAt,
                        CustomClaimNames.Permission
                    } // so this resource will return claims that belong to profile scope + our securitygroup claim, just to demonstrate that we can create different resources
                },
                new IdentityResource
                {
                    Description = "Users membership status",
                    DisplayName = "Membership status",
                    Name = CustomScopeNames.MembershipStatus,
                    UserClaims = new List<string>
                    {
                        CustomClaimNames.MemberNumber
                    }
                }
            };
        }
    }
}
