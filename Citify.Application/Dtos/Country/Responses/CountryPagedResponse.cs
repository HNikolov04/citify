namespace Citify.Application.Dtos.Country.Responses;

public record CountryPagedResponse(
    IEnumerable<CountryDto> Items,
    int TotalCount
);
