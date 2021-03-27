using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasmAuth.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly TokenSessionState _tokenSession;

        public CustomAuthenticationStateProvider(TokenSessionState tokenSession)
        {
            _tokenSession = tokenSession;
            _tokenSession.OnChange+= OnTokenChange;
        }

        private void OnTokenChange(string token)
        {
            //You can store the token somewhere
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!_tokenSession.HasToken) return new AuthenticationState(new ClaimsPrincipal());

            //Return anonymous
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _tokenSession.GetToken.Replace("username:", ""))
            }, "fake_data");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }

        public void SignIn(string username, string password)
        {
            _tokenSession.SetToken("username:" + username);
        }

        public void SignOut()
        {
            _tokenSession.SetToken("");
        }
    }

    public class TokenSessionState
    {
        private string _token;

        public Action<string> OnChange;
        public bool HasToken => !string.IsNullOrEmpty(_token);
        public string GetToken => _token;

        public void SetToken(string token)
        {
            _token = token;
            OnChange?.Invoke(token);
        }

    }
}
