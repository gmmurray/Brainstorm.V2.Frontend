using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Brainstorm.V2.Frontend.Extensions
{
  public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
  {
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager, IConfiguration configuration) : base(provider, navigationManager)
    {
      ConfigureHandler(
        authorizedUrls: new[] { configuration["Server:BaseUrl"] }
      );
    }
  }
}