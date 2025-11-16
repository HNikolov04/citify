using Citify.Domain.Entities;
using Citify.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace Citify.Api.Extensions;

public static class AddIdentityServices
{
    public static IServiceCollection AddIdentityLayer(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<CitifyDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }
}
