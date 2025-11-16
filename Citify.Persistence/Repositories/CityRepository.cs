using Citify.Domain.Entities;
using Citify.Persistence.Context;
using Citify.Persistence.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Citify.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly CitifyDbContext _context;

    public CityRepository(CitifyDbContext context)
    {
        _context = context;
    }

    public Task<City?> GetByIdAsync(Guid id)
    {
        return _context.Cities
            .Include(c => c.Country)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<City?> GetByNameAsync(string name)
    {
        return _context.Cities.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<IReadOnlyList<City>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await _context.Cities
            .Include(c => c.Country)
            .OrderBy(c => c.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<int> CountAsync()
    {
        return _context.Cities.CountAsync();
    }

    public async Task AddAsync(City city)
    {
        await _context.Cities.AddAsync(city);
    }

    public Task UpdateAsync(City city)
    {
        _context.Cities.Update(city);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(City city)
    {
        _context.Cities.Remove(city);

        return Task.CompletedTask;
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _context.Cities.AnyAsync(c => c.Name == name);
    }
}
