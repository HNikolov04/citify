using Citify.Domain.Entities.Base;

namespace Citify.Domain.Entities;

public class Country : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<City> Cities { get; set; } = new HashSet<City>();
}
