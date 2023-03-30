using System.ComponentModel.DataAnnotations;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    
    [Timestamp]
    public byte[] RowVersion { get; private set; }

    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && CreatedAt.Equals(other.CreatedAt);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, CreatedAt);
    }
}