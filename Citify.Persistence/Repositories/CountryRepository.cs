using Citify.Domain.Entities;
using Citify.Persistence.Context;
using Citify.Persistence.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Citify.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly CitifyDbContext _context;

    public CountryRepository(CitifyDbContext context)
    {
        _context = context;
    }

    public async Task<Country?> GetByIdAsync(Guid id)
    {
        return await _context.Countries
            .Include(c => c.Cities)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<Country?> GetByNameAsync(string name)
    {
        return _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<IReadOnlyList<Country>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await _context.Countries
            .OrderBy(c => c.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<int> CountAsync()
    {
        return _context.Countries.CountAsync();
    }

    public async Task AddAsync(Country country)
    {
        await _context.Countries.AddAsync(country);
    }

    public Task UpdateAsync(Country country)
    {
        _context.Countries.Update(country);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Country country)
    {
        _context.Countries.Remove(country);

        return Task.CompletedTask;
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _context.Countries.AnyAsync(c => c.Name == name);
    }
}
