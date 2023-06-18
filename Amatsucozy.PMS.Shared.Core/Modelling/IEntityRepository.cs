using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IEntityRepository<in TId, TRowVersion, TEntity>
    where TId : notnull, new()
    where TRowVersion : notnull
    where TEntity : IEntity<TId, TRowVersion>
{
    Result<TEntity> Find(TId id);

    Result<bool> Save(TEntity entity);
}