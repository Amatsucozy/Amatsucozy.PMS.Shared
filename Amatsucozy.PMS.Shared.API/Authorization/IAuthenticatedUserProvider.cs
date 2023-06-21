namespace Amatsucozy.PMS.Shared.API.Authorization;

public interface IAuthenticatedUserProvider
{
    AuthenticatedUser User { get; }
}
