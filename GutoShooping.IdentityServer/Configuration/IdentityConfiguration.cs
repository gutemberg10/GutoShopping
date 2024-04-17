using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GutoShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public static string Admin = "Admin";
        public static string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "User roles", new List<string> { "role" }) // Definindo um novo recurso de identidade para os papéis dos usuários
    };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Guto_shopping", "GutoShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data."),
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read",  "write", "profile"}
                },
                new Client
                {
                    ClientId = "Guto_shopping",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-casllback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "Guto_shopping",
                        "roles" // Adicionando o novo recurso de identidade de "roles" aos escopos permitidos          
                    },
                    AlwaysIncludeUserClaimsInIdToken = true // Garantindo que as reivindicações do usuário sejam incluídas no token de ID
                }

            };  
    }
}
