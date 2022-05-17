using Brainstorm.V2.Frontend;
using Brainstorm.V2.Frontend.Extensions;
using Brainstorm.V2.Frontend.Extensions.AuthExtensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("WebAPI", client => client.BaseAddress = new Uri(builder.Configuration["Server:BaseUrl"]!))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"));

builder.Services.AddAuth0OidcAuthentication(options =>
{
  builder.Configuration.Bind("Auth0", options.ProviderOptions);
  options.ProviderOptions.ResponseType = "code";
  options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
  options.ProviderOptions.MetadataSeed.EndSessionEndpoint = $"{builder.Configuration["Auth0:Authority"]}/v2/logout?client_id={builder.Configuration["Auth0:ClientId"]}&returnTo={builder.HostEnvironment.BaseAddress}";
});

await builder.Build().RunAsync();
