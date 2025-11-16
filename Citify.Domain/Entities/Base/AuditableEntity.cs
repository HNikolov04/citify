using Citify.Domain.Entities.Contracts;

namespace Citify.Domain.Entities.Base;

public abstract class AuditableEntity : BaseEntity, IAuditable
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
