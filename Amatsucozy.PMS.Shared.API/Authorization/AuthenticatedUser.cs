using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ScopesStaticClass = Amatsucozy.PMS.Shared.API.Authorization.Scopes;

namespace Amatsucozy.PMS.Shared.API.Authorization;

public record AuthenticatedUser
{
    public AuthenticatedUser(HttpContext context, string authority)
    {
        Id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        Scopes = context.User
                     .FindFirst(c => c.Type == ScopesStaticClass.ClaimType && c.Issuer == authority)
                     ?.Value
                     .Split(' ')
                     .Aggregate(
                         ScopesFlag.None,
                         (scopesEnum, scope) =>
                         {
                             if (!ScopesStaticClass.ScopesDictionary.TryGetValue(scope, out var scopeEnum))
                                 return scopesEnum;

                             scopesEnum |= scopeEnum;

                             return scopesEnum;
                         })
                 ?? ScopesFlag.None;
        IsValid = !string.IsNullOrWhiteSpace(Id) && Scopes != ScopesFlag.None;
    }

    public ScopesFlag Scopes { get; }

    public string Id { get; }

    public bool IsValid { get; }
}
