using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IEntityRepository<in TId, TEntityDomain>
    where TId : notnull
    where TEntityDomain : IEntityDomain<TId>
{
    Result<TEntityDomain> Find(TId id);

    Result<bool> Save(TEntityDomain entity);
}
