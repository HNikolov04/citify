using Citify.Application.Dtos.City.Requests;
using Citify.Application.Dtos.City.Responses;
using Citify.Domain.Entities;

namespace Citify.Application.Mappers.Contracts;

public interface ICityMapper
{
    CityDto ToDto(City entity);
    City ToEntity(CityCreateRequest request);
    void MapUpdate(CityUpdateRequest request, City entity);
}
