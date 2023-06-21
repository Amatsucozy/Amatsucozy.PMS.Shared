using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IEntityRepository<in TId, TRowVersion, TEntity, TEntityDomain>
    where TId : notnull
    where TRowVersion : notnull
    where TEntity : IEntity<TId, TRowVersion>
    where TEntityDomain : IEntityDomain<TId, TRowVersion, TEntity>
{
    Result<TEntityDomain> Find(TId id);

    Result<bool> Save(TEntityDomain entity);
}