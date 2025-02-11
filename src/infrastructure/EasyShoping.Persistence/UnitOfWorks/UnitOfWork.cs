using EasyShoping.Application.Repositories;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Persistence.Contexts;
using EasyShoping.Persistence.Repositories;

namespace EasyShoping.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly EasyShopingDbContext _dbContext;

    public UnitOfWork(EasyShopingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Dispose() => _dbContext.Dispose();
    public int Save() => _dbContext.SaveChanges();
    public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    IReadRepository<Tentity> IUnitOfWork.GetReadRepository<Tentity>() => new ReadRepository<Tentity>(_dbContext);
    IWriteRepository<Tentity> IUnitOfWork.GetWriteRepository<Tentity>() => new WriteRepository<Tentity>(_dbContext);
}
