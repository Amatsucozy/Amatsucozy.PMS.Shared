using System.ComponentModel.DataAnnotations;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public abstract class Entity : IEqualityComparer<Entity>
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
    
    public DateTimeOffset CreatedAt { get; protected init; } = DateTimeOffset.UtcNow;
    
    public DateTimeOffset UpdatedAt { get; protected set; } = DateTimeOffset.UtcNow;

    [Timestamp]
    public byte[] RowVersion { get; protected set; } = new byte[8];

    public bool Equals(Entity x, Entity y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id.Equals(y.Id) && x.CreatedAt.Equals(y.CreatedAt) && x.RowVersion.Equals(y.RowVersion);
    }

    public int GetHashCode(Entity obj)
    {
        return HashCode.Combine(obj.Id, obj.CreatedAt, obj.RowVersion);
    }
}