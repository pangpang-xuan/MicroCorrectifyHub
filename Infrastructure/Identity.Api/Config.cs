using Duende.IdentityServer.Models;
using IdentityModel;

namespace RecALLDemo.Infrastructure.Identity.Api;




public class Config {
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource> {
            new IdentityResources.OpenId(), new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> {
            new("List", "List") { UserClaims = { JwtClaimTypes.Audience } },
            new("TextList", "Text List") {
                UserClaims = { JwtClaimTypes.Audience }
            }
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource> {
            new("List", "List") {
                Scopes = { "List" }, UserClaims = { JwtClaimTypes.Audience }
            },
            new("TextList", "Text List") {
                Scopes = { "TextList" }, UserClaims = { JwtClaimTypes.Audience }
            }
        };

    public static IEnumerable<Client>
        GetClients(Dictionary<string, string> clientUrlDict) =>
        new List<Client> {
            new() {
                ClientId = "ListApiSwaggerUI",
                ClientName = "ListApiSwaggerUI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {
                    $"{clientUrlDict["ListApi"]}/swagger/oauth2-redirect.html"
                },
                PostLogoutRedirectUris = {
                    $"{clientUrlDict["ListApi"]}/swagger/"
                },
                AllowedScopes = { "List", "TextList" }
            },
            new() {
                ClientId = "TextListApiSwaggerUI",
                ClientName = "TextListApiSwaggerUI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {
                    $"{clientUrlDict["TextListApi"]}/swagger/oauth2-redirect.html"
                },
                PostLogoutRedirectUris = {
                    $"{clientUrlDict["TextListApi"]}/swagger/"
                },
                AllowedScopes = { "TextList" }
            }
        };
}