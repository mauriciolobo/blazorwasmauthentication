# Blazor WASM (Webassembly) simple authentication

This is a small sample of how to user Blazor AuthenticationStateProvider

----

## Initial Setup
1. Install ```Microsoft.AspNetCore.Components.WebAssembly.Authentication```
1. In App.razor add ```builder.Services.AddAuthorizationCore();```
1. Create ```CustomAuthenticationStateProvider.cs```
1. Add ```Microsoft.AspNetCore.Components.Authorization``` into _Imports.razor
1. Can use ```AuthorizeView``` with ```Authorized``` and ```NotAuthorized```

### Implementation
1. Create an in memory TokenState manager
1. Create a Sign In / Sign out method
1. Protect page with ```@attribute [Authorize]```