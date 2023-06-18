namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IPostgresEntity<out TId> : IEntity<TId, uint>
    where TId : notnull, new()
{
}