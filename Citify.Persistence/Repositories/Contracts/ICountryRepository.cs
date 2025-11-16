using Citify.Domain.Entities;

namespace Citify.Persistence.Repositories.Contracts;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(Guid id);
    Task<Country?> GetByNameAsync(string name);

    Task<IReadOnlyList<Country>> GetPagedAsync(int pageNumber, int pageSize);
    Task<int> CountAsync();

    Task AddAsync(Country country);
    Task UpdateAsync(Country country);
    Task DeleteAsync(Country country);

    Task<bool> ExistsByNameAsync(string name);
}