# Simple IdentityServer4.Quickstart.UI based OIDC configuration for developers using ASP.NET Core

See the GitHub repository of [IdentityServer4.Quickstart.UI](https://github.com/IdentityServer/IdentityServer4.Quickstart.UI)

I've created this mainly for Episerver demo how to use OpenID Connect with Episerver but you can clone or download the code and change the configuration to match your needs.

Configuration includes couple of users, a client and needed IdentityResources. These can be found from the *InMemory* folder in the project.

## Changes to Quickstart UI
Views\Consent\Index.cshtml and Views\Account\Login.cshtml
- @Html.Partial(...) calls changed to @await Html.PartialAsyn(...)

## Configuration changes

Quickstart\Account\AccountOptions.cs
- AutomaticRedirectAfterSignOut changed to true

## Development setup
You will need .NET Core 2.1

Solution done with Visual Studio 2017

## Running the server
You can use the **Start IdSrv.cmd** included in the solution folder **_or_** run it directly from Visual Studio using the _Swapcode.IdentityServer.ForDevs_ profile.

## Customizing the users, scopes and clients
Modify the in memory configurations in *InMemory* folder.

Read the [IdentityServer4 documentation](https://identityserver4.readthedocs.io/en/release/).

#### UsersConfig.cs
Users and their claims.

#### ClientsConfig.cs
Clients configuration, OpenID Connect or OAuth2 client.

**TODO for you**: you need to change here the *DefaultSiteAddress* and *UtilFolderAddress* values to match your site addresses.

#### IdentityResourcesConfig.cs
Configured identity resources, like the standard scopes OpenId, Profile and some custom scopes.
Clients requesting scopes map to these IdentityResources.

For example there is a custom scope named *PROFILEWITHPERMGROUPUSER* (CustomScopeNames.ProfilePermissionGroup) which returns the same claims as prfoile but also users permission claims (custom claim).

#### PermissionGroupNames.cs
Contains constants for some demo permission (security or role) groups. Like something that might be in the backend systems.

#### CustomClaimNames.cs
Contains constants for custom claim names.

#### CustomScopeNames.cs
Contains constants for custom scope names.
