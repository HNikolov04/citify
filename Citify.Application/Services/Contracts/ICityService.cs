using Citify.Application.Dtos.City.Requests;
using Citify.Application.Dtos.City.Responses;

namespace Citify.Application.Services.Contracts;

public interface ICityService
{
    Task<CityDto> CreateAsync(CityCreateRequest request);
    Task<CityDto> UpdateAsync(CityUpdateRequest request);
    Task DeleteAsync(Guid id);
    Task<CityDto> GetByIdAsync(Guid id);
    Task<CityPagedResponse> GetPagedAsync(int pageNumber, int pageSize);
}
