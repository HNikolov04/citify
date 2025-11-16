using Citify.Persistence.Context;
using Citify.Persistence.Repositories;
using Citify.Persistence.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Citify.Api.Extensions;

public static class AddPersistenceServices
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration config)
    {
        var conn = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<CitifyDbContext>(options =>
            options.UseSqlServer(conn));

        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
