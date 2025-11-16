using Citify.Domain.Entities.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Citify.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>, IAuditable
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
