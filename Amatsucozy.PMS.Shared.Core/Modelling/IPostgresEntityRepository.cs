namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IPostgresEntityRepository<in TId, TEntity> : IEntityRepository<TId, uint, TEntity>
    where TId : notnull, new()
    where TEntity : IEntity<TId, uint>
{
}