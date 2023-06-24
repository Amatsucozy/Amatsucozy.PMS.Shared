using Amatsucozy.PMS.Shared.API.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.PMS.Shared.API.Authorization;

public static class AuthorizationInjector
{
    public static void AddAuthorizationHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpContextAccessor();

        serviceCollection.AddScoped<IAuthenticatedUserProvider, AuthenticatedUserProvider>();
        serviceCollection.AddScoped<IAuthorizationHandler, HasScopeHandler>();
    }
}
