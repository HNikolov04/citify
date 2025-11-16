using Citify.Persistence.Context;
using Citify.Persistence.Repositories.Contracts;

namespace Citify.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CitifyDbContext _context;

    public UnitOfWork(CitifyDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
