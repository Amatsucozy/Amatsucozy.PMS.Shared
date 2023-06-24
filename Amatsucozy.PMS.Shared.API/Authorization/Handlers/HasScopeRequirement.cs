using Microsoft.AspNetCore.Authorization;

namespace Amatsucozy.PMS.Shared.API.Authorization.Handlers;

public sealed class HasScopeRequirement : IAuthorizationRequirement
{
    public HasScopeRequirement(string issuer, ScopesFlags scopes)
    {
        Scopes = scopes;
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }

    public string Issuer { get; }

    public ScopesFlags Scopes { get; }
}
