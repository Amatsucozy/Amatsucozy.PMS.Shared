namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface ISqlServerEntityRepository<in TId, TEntity, TEntityDomain>
    : IEntityRepository<TId, byte[], TEntity, TEntityDomain>
    where TId : notnull, new()
    where TEntity : IEntity<TId, byte[]>
    where TEntityDomain : IEntityDomain<TId, byte[], TEntity>
{
}