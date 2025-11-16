using Citify.Application.Dtos.Country.Requests;
using Citify.Application.Dtos.Country.Responses;

namespace Citify.Application.Services.Contracts;

public interface ICountryService
{
    Task<CountryDto> CreateAsync(CountryCreateRequest request);
    Task<CountryDto> UpdateAsync(CountryUpdateRequest request);
    Task DeleteAsync(Guid id);
    Task<CountryDto> GetByIdAsync(Guid id);
    Task<CountryPagedResponse> GetPagedAsync(int pageNumber, int pageSize);
}

