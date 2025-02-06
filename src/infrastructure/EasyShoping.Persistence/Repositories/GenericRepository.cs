using EasyShoping.Domain.Entities.Common;
using EasyShoping.Domain.Repositories;
using EasyShoping.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace EasyShoping.Persistence.Repositories;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class, IBaseEntity, new()
{
    private readonly EasyShopingDbContext _Dbcontext;
    private readonly DbSet<Tentity> DbTable;

    public GenericRepository(EasyShopingDbContext easyShopingDbContext)
    {
        _Dbcontext = easyShopingDbContext;
        var table = _Dbcontext.Set<Tentity>();
        DbTable= table;
    }

    public async Task CommitAsync()
    {
        await _Dbcontext.SaveChangesAsync();

    }

    public Task<Tentity> DeleteAsync(Tentity tentity)
    {
        throw new NotImplementedException();
    }

    public List<Tentity> GetAllAsync(Expression<Func<Tentity, bool>> expression, params string[] include)
    {
        throw new NotImplementedException();
    }

    public Tentity GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Tentity GetSingleAsync(Expression<Func<Tentity, bool>> expression, params string[] include)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(Tentity entity)
    {
        throw new NotImplementedException();
    }
}
