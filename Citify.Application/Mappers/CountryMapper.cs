using Citify.Application.Dtos.Country.Requests;
using Citify.Application.Dtos.Country.Responses;
using Citify.Application.Mappers.Contracts;
using Citify.Domain.Entities;

namespace Citify.Application.Mappers;

public class CountryMapper : ICountryMapper
{
    public CountryDto ToDto(Country entity)
    {
        return new(entity.Id, entity.Name);
    }

    public Country ToEntity(CountryCreateRequest request)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
    }

    public void MapUpdate(CountryUpdateRequest request, Country entity)
    {
        entity.Name = request.Name;
    }
}
