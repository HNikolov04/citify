namespace Citify.Application.Dtos.Auth.Requests;

public record RegisterRequest(string UserName, string Email, string Password);
