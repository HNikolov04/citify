namespace Citify.Application.Dtos.City.Requests;

public record CityCreateRequest(string Name, Guid CountryId);
