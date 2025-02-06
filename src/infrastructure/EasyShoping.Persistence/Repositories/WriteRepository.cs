using EasyShoping.Domain.Entities.Common;
using EasyShoping.Domain.Repositories;
using EasyShoping.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyShoping.Persistence.Repositories;

public class WriteRepository<Tentity> : IWriteRepository<Tentity> where Tentity : class, IBaseEntity, new()
{
    private readonly EasyShopingDbContext _dbContext;
    private DbSet<Tentity> DbTable { get => _dbContext.Set<Tentity>(); }
    public WriteRepository(EasyShopingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(Tentity entity)
    {
        await DbTable.AddAsync(entity);
    }

    public async Task AddRangeAsync(List<Tentity> entities)
    {
        await DbTable.AddRangeAsync(entities);
    }

    public async void Delete(Tentity entity)
    {
        await Task.Run(() => DbTable.Remove(entity));
    }

    public async Task<Tentity> UpdateAsync(Tentity entity)
    {
        await Task.Run(() => DbTable.Update(entity));
        return entity;
    }
}
