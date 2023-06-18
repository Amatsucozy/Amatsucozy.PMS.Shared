namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IEntityDomain<out TId, TRowVersion, TEntity>
    where TId : notnull, new()
    where TRowVersion : notnull
    where TEntity : IEntity<TId, TRowVersion>
{
    TId Id { get; }
}