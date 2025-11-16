namespace Citify.Application.Dtos.City.Responses;

public record CityDto(Guid Id, string Name, Guid CountryId, string CountryName);
