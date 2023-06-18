namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IPostgresEntityRepository<in TId, TEntity, TEntityDomain>
    : IEntityRepository<TId, uint, TEntity, TEntityDomain>
    where TId : notnull, new()
    where TEntity : IEntity<TId, uint>
    where TEntityDomain : IEntityDomain<TId, uint, TEntity>
{
}