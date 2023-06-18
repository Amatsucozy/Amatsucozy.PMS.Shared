namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface ISqlServerEntity<out TId> : IEntity<TId, byte[]>
    where TId : notnull, new()
{
}