using Citify.Domain.Entities.Base;

namespace Citify.Domain.Entities;

public class City : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid CountryId { get; set; }
    public Country? Country { get; set; }
}