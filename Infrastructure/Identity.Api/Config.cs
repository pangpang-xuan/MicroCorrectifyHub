using Duende.IdentityServer.Models;
using IdentityModel;

namespace RecALLDemo.Infrastructure.Identity.Api;




public class Config {
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource> {
            new IdentityResources.OpenId(), new IdentityResources.Profile()
        };

    //apiscopes 被保护的微服务  scope -- resources 一一对应
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> {
            new("List", "List") { UserClaims = { JwtClaimTypes.Audience } },
            new("TextList", "Text List") {
                UserClaims = { JwtClaimTypes.Audience }
            },
            new("MaskedTextList", "MaskedText List") {
                UserClaims = { JwtClaimTypes.Audience }
            } //maskedtextitem
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource> {
            new("List", "List") {
                Scopes = { "List" }, UserClaims = { JwtClaimTypes.Audience }
            },
            new("TextList", "Text List") {
                Scopes = { "TextList" }, UserClaims = { JwtClaimTypes.Audience }
            },
            new("MaskedTextList", "MaskedText List") {
                Scopes = { "MaskedTextList" }, UserClaims = { JwtClaimTypes.Audience }
            }  //maskedtextitem
        };

    // 客户端 ui 界面  其中的ListAPI与appsetting对应
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
                AllowedScopes = { "List", "TextList","MaskedTextList" }  //add new maskedtextlist
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
            },
            new() {
                ClientId = "MaskedTextListApiSwaggerUI",
                ClientName = "MaskedTextListApiSwaggerUI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {
                    $"{clientUrlDict["MaskedTextListApi"]}/swagger/oauth2-redirect.html"
                },
                PostLogoutRedirectUris = {
                    $"{clientUrlDict["MaskedTextListApi"]}/swagger/"
                },
                AllowedScopes = { "MaskedTextList" }
            }
        };
}