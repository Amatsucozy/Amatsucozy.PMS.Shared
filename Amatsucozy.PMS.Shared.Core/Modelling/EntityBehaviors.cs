namespace Amatsucozy.PMS.Shared.Core.Modelling;

public sealed class EntityBehaviors<TEntity> where TEntity : Entity
{
    protected TEntity Entity { get; }

    public EntityBehaviors(TEntity entity)
    {
        Entity = entity;
    }
}