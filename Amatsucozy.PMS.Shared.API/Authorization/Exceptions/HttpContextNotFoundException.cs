namespace Amatsucozy.PMS.Shared.API.Authorization.Exceptions;

public sealed class HttpContextNotFoundException : Exception
{
    public HttpContextNotFoundException(string message) : base(message)
    {
    }
}
