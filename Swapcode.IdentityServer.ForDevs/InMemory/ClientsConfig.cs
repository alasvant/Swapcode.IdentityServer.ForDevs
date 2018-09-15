using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Swapcode.IdentityServer.ForDevs.InMemory
{
    /// <summary>
    /// Contains in memory clients configuration.
    /// </summary>
    public static class ClientsConfig
    {
        /// <summary>
        /// The default site (most likely your localhost)
        /// </summary>
        private const string DefaultSiteAddress = "http://localhost:46013"; // TODO: Change here your site address and port. Do not add backslash at the end!
        /// <summary>
        /// Your Episerver site util folder.
        /// </summary>
        private const string UtilFolderAddress = "util"; // TODO: change your Episerver util folder path here

        public static IEnumerable<Client> GetClients()
        {
            // define the in memory clients here

            return new List<Client>
            {
                new Client
                {
                    ClientId = "epi-alloy-mvc",
                    ClientName = "Episerver MVC Alloy Site",
                    ClientSecrets =
                    {
                        new Secret("epi-alloy-mvc-very-secret".Sha256())
                    },
                    RequireConsent = false, // should consent screen be displayed
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowOfflineAccess = false, // to get the refresh token set this to true
                    AllowedCorsOrigins =
                    {
                        DefaultSiteAddress
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        CustomScopeNames.ProfileWithPermissions,
                        CustomScopeNames.MembershipStatus
                    },
                    RedirectUris =
                    {
                        DefaultSiteAddress
                    },
                    PostLogoutRedirectUris =
                    {
                        DefaultSiteAddress
                    },
                    FrontChannelLogoutUri = $"{DefaultSiteAddress}/{UtilFolderAddress}/logout.aspx"
                }
            };
        }
    }
}
