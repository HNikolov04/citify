namespace Citify.Application.Dtos.City.Responses;

public record CityPagedResponse(
    IEnumerable<CityDto> Items,
    int TotalCount
);
