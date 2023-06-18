using System.ComponentModel.DataAnnotations;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public abstract class Entity
{
    [Key]
    public Guid Id { get; protected init; } = Guid.NewGuid();
    
    public DateTimeOffset CreatedAt { get; protected init; } = DateTimeOffset.UtcNow;
    
    public DateTimeOffset UpdatedAt { get; protected set; } = DateTimeOffset.UtcNow;

    [Timestamp]
    public uint RowVersion { get; protected set; }
}