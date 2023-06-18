using System.ComponentModel.DataAnnotations;

namespace Amatsucozy.PMS.Shared.Core.Modelling;

public interface IEntity<out TId, out TRowVersion>
    where TId : notnull, new()
    where TRowVersion : notnull
{
    TId Id { get; }

    DateTimeOffset CreatedAt { get; }

    DateTimeOffset UpdatedAt { get; }

    [Timestamp]
    TRowVersion RowVersion { get; }
}