namespace Citify.Application.Dtos.Auth.Requests;

public record LoginRequest(string UserNameOrEmail, string Password);
