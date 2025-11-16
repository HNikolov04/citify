namespace Citify.Application.Dtos.City.Requests;

public record CityUpdateRequest(Guid Id, string Name, Guid CountryId);
