using RecALLDemo.Infrastructure.Identity.Api;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddRazorPages();

// services.AddIdentityServer()
//     .AddInMemoryIdentityResources(Config.IdentityResources)
//     .AddInMemoryApiScopes(Config.ApiScopes).AddInMemoryClients(Config.Clients)
//     .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.UseCookiePolicy(
    new CookiePolicyOptions {MinimumSameSitePolicy = SameSiteMode.Lax});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

