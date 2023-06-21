using Microsoft.AspNetCore.Authorization;

namespace Amatsucozy.PMS.Shared.API.Authorization.Handlers;

public sealed class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    private readonly AuthenticatedUserProvider _authenticatedUserProvider;

    public HasScopeHandler(AuthenticatedUserProvider authenticatedUserProvider)
    {
        _authenticatedUserProvider = authenticatedUserProvider;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        if (!_authenticatedUserProvider.User.IsValid)
        {
            return Task.CompletedTask;
        }

        if ((_authenticatedUserProvider.User.Scopes & requirement.Scopes) == requirement.Scopes)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
