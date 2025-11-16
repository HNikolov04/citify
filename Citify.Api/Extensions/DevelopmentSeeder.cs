using Citify.Domain.Entities;
using Citify.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Citify.Api.Extensions;

public static class DevelopmentSeeder
{
    public static async Task<IApplicationBuilder> SeedDevelopmentDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

        if (!env.IsDevelopment())
        {
            return app;
        }

        var db = scope.ServiceProvider.GetRequiredService<CitifyDbContext>();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await db.Database.MigrateAsync();

        if (!await db.Countries.AnyAsync())
        {
            var bg = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };
            var de = new Country { Id = Guid.NewGuid(), Name = "Germany" };
            var fr = new Country { Id = Guid.NewGuid(), Name = "France" };

            await db.Countries.AddRangeAsync(bg, de, fr);

            await db.Cities.AddRangeAsync(
                new City { Id = Guid.NewGuid(), Name = "Sofia", CountryId = bg.Id },
                new City { Id = Guid.NewGuid(), Name = "Plovdiv", CountryId = bg.Id },
                new City { Id = Guid.NewGuid(), Name = "Berlin", CountryId = de.Id },
                new City { Id = Guid.NewGuid(), Name = "Munich", CountryId = de.Id },
                new City { Id = Guid.NewGuid(), Name = "Paris", CountryId = fr.Id }
            );

            await db.SaveChangesAsync();
        }

        var testUser = await userManager.FindByEmailAsync("test@citify.com");

        if (testUser == null)
        {
            testUser = new ApplicationUser
            {
                UserName = "testuser",
                Email = "test@citify.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(testUser, "Test123!");
        }

        return app;
    }
}
