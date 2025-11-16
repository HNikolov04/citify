using Citify.Application.Dtos.Country.Requests;
using Citify.Application.Dtos.Country.Responses;
using Citify.Domain.Entities;

namespace Citify.Application.Mappers.Contracts;

public interface ICountryMapper
{
    CountryDto ToDto(Country entity);
    Country ToEntity(CountryCreateRequest request);
    void MapUpdate(CountryUpdateRequest request, Country entity);
}
