using Citify.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Citify.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task<IApplicationBuilder> ApplyMigrationsAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<CitifyDbContext>();

        await db.Database.MigrateAsync();

        return app;
    }
}
