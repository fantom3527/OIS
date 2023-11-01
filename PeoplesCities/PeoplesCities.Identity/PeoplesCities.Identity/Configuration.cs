using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace PeoplesCities.Identity
{
    public static class Configuration
    {
        /// <summary>
        /// Список разрешений.
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("PeoplesCitiesWebAPI", "Web API")
            };

        /// <summary>
        /// Список идентификационных ресурсов.
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Список API-ресурсов, к которым можно запрашивать доступ.
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("PeoplesCitiesWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "PeoplesCitiesWebAPI" }
                }
            };

        /// <summary>
        /// Список клиентских приложений, которым разрешено получать токены доступа.
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "PeoplesCities-web-api",
                    ClientName = "PeoplesCities Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://localhost:3000/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3000/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "PeoplesCitiesWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}