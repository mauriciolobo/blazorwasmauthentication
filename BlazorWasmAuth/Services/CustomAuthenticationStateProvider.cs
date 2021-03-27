using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasmAuth.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //Return anonymous
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new []{new Claim(ClaimTypes.Name, "anonymous")}, "fake_auth"))));
        }
    }
}
