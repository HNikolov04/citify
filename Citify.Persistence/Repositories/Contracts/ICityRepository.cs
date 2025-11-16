using Citify.Domain.Entities;

namespace Citify.Persistence.Repositories.Contracts;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(Guid id);
    Task<City?> GetByNameAsync(string name);

    Task<IReadOnlyList<City>> GetPagedAsync(int pageNumber, int pageSize);
    Task<int> CountAsync();

    Task AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(City city);

    Task<bool> ExistsByNameAsync(string name);
}
