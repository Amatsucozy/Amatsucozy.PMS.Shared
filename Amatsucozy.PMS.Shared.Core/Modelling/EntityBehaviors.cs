namespace Amatsucozy.PMS.Shared.Core.Modelling;

public abstract class EntityBehaviors<TEntity> where TEntity : Entity
{
    protected TEntity Entity { get; }

    protected EntityBehaviors(TEntity entity)
    {
        Entity = entity;
    }
}