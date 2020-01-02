using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Ecommerce.Auth
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "shanto",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "hasib",
                    Password = "password"
                }

            };

        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "web_client",
                    ClientName = "web_client",
                    AllowedGrantTypes =IdentityServer4.Models.GrantTypes.Hybrid,
                    ClientSecrets = new List<Secret>(){new Secret("secret".Sha256())},
                    // where to redirect to after login
                    RedirectUris ={"https://localhost:44314/signin-oidc"},
                    // where to redirect to after logout
                   //PostLogoutRedirectUris = {"https://localhost:44314/signout-callback-oidc"},
                    AllowedScopes =new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                       "ecommerce_api"
                    },
                    AllowOfflineAccess = true
                },
                


            };
        }
    }
}