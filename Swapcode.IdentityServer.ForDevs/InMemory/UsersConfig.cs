using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Swapcode.IdentityServer.ForDevs.InMemory
{
    /// <summary>
    /// Contains in memory users configuration.
    /// </summary>
    public static class UsersConfig
    {
        public static List<TestUser> GetUsers()
        {
            // define your users here

            return new List<TestUser>
            {
                // site admin
                new TestUser
                {
                    SubjectId = "4A0D610F-5781-4E1F-B808-2E86E502BF10",
                    Username = "siteadmin",
                    Password = "NeverForget95!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Admin Siteadmin"),
                        new Claim(JwtClaimTypes.GivenName, "Admin"),
                        new Claim(JwtClaimTypes.FamilyName, "Siteadmin"),
                        new Claim(JwtClaimTypes.PreferredUserName, "siteadmin"),
                        new Claim(JwtClaimTypes.Email, "siteadmin@example.com"),
                        new Claim(CustomClaimNames.Permission, PermissionGroupNames.WebSiteSuperUser) // there could be multiple claims with the same name
                    }
                },
                // site editor
                new TestUser
                {
                    SubjectId = "205068EE-574B-4534-834B-607BFFBDD20E",
                    Username = "siteeditor",
                    Password = "Salt&Pepper95!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Editor Siteeditor"),
                        new Claim(JwtClaimTypes.GivenName, "Editor"),
                        new Claim(JwtClaimTypes.FamilyName, "Siteeditor"),
                        new Claim(JwtClaimTypes.PreferredUserName, "siteeditor"),
                        new Claim(JwtClaimTypes.Email, "siteeditor@example.com"),
                        new Claim(CustomClaimNames.Permission, PermissionGroupNames.WebSiteEditor) // there could be multiple claims with the same name
                    }
                },
                // site reader (can access edit view but cannot make any modifications to content)
                new TestUser
                {
                    SubjectId = "3006293C-35CE-45B5-AFD3-F475495DB2C3",
                    Username = "sitereader",
                    Password = "SaltedReader95!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Reader Sitereader"),
                        new Claim(JwtClaimTypes.GivenName, "Reader"),
                        new Claim(JwtClaimTypes.FamilyName, "Sitereader"),
                        new Claim(JwtClaimTypes.PreferredUserName, "sitereader"),
                        new Claim(JwtClaimTypes.Email, "sitereader@example.com"),
                        new Claim(CustomClaimNames.Permission, PermissionGroupNames.WebSiteReader) // there could be multiple claims with the same name
                    }
                },
                // site member, registered user or user coming from backend system like a customer of a company
                new TestUser
                {
                    SubjectId = "D6AD6517-A83B-41A0-B012-14DA7809935C",
                    Username = "sitemember",
                    Password = "MorningStar95!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Member Sitemember"),
                        new Claim(JwtClaimTypes.GivenName, "Member"),
                        new Claim(JwtClaimTypes.FamilyName, "Sitemember"),
                        new Claim(JwtClaimTypes.PreferredUserName, "sitemember"),
                        new Claim(JwtClaimTypes.Email, "sitemember@example.com"),
                        new Claim(CustomClaimNames.MemberNumber, "ZZ2984784")
                    }
                } // demo site member user, no access to edit or admin views, like a registered user or a customer from backend systems
            };
        }
    }
}
