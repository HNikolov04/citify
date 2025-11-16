using Citify.Domain.Entities;
using Citify.Domain.Entities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Citify.Persistence.Context;

public class CitifyDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public CitifyDbContext(DbContextOptions<CitifyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CitifyDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditable &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            var auditable = (IAuditable)entry.Entity;

            if (entry.State == EntityState.Added)
                auditable.CreatedAt = now;

            auditable.ModifiedAt = now;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
