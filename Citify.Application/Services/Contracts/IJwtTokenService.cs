using Citify.Domain.Entities;

namespace Citify.Application.Services.Contracts;

public interface IJwtTokenService
{
    string GenerateToken(ApplicationUser user);
}
