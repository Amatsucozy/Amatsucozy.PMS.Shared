namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface ISqlServerEntityRepository<in TId, TEntity> : IEntityRepository<TId, byte[], TEntity>
    where TId : notnull, new()
    where TEntity : IEntity<TId, byte[]>
{
}