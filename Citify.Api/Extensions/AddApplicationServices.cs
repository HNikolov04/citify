using Citify.Application.Mappers;
using Citify.Application.Mappers.Contracts;
using Citify.Application.Services;
using Citify.Application.Services.Contracts;

namespace Citify.Api.Extensions;

public static class AddApplicationServices
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICityMapper, CityMapper>();
        services.AddScoped<ICountryMapper, CountryMapper>();

        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }
}
