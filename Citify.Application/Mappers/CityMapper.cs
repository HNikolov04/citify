using Citify.Application.Dtos.City.Requests;
using Citify.Application.Dtos.City.Responses;
using Citify.Application.Mappers.Contracts;
using Citify.Domain.Entities;

namespace Citify.Application.Mappers;

public class CityMapper : ICityMapper
{
    public CityDto ToDto(City entity)
    {
        return new(
                entity.Id,
                entity.Name,
                entity.CountryId,
                entity.Country?.Name ?? string.Empty
            );
    }

    public City ToEntity(CityCreateRequest request)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CountryId = request.CountryId
        };
    }

    public void MapUpdate(CityUpdateRequest request, City entity)
    {
        entity.Name = request.Name;
        entity.CountryId = request.CountryId;
    }
}
