using EasyShoping.Domain.Entities.Common;
using EasyShoping.Application.Repositories;
using EasyShoping.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EasyShoping.Persistence.Repositories;

public class ReadRepository<Tentity> : IReadRepository<Tentity> where Tentity : class, IBaseEntity, new()
{
    private readonly EasyShopingDbContext _Dbcontext;
    private DbSet<Tentity> DbTable { get => _Dbcontext.Set<Tentity>(); }

    public ReadRepository(EasyShopingDbContext easyShopingDbContext)
    {
        _Dbcontext = easyShopingDbContext;
    }

    public async Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>>? expression = null, Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null, Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>>? orderBy = null, bool enableTracking = false)
    {
        var query = DbTable.AsQueryable();
        if (!enableTracking) query = query.AsNoTracking();
        if (expression is not null) query = query.Where(expression);
        if (include is not null) query = include(query);
        if (orderBy is not null) return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<Tentity> GetSingleAsync(Expression<Func<Tentity, bool>> expression, Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null, bool enableTracking = false)
    {
        var query = DbTable.AsQueryable();
        query = query.Where(expression);
        if (!enableTracking) query = query.AsNoTracking();
        if (include is not null) query = include(query);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<Tentity>> GetAllByPagingAsync(Expression<Func<Tentity, bool>>? expression = null, Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null, Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        var query = DbTable.AsQueryable();
        if (!enableTracking) query = query.AsNoTracking();
        if (expression is not null) query = query.Where(expression);
        if (include is not null) query = include(query);
        if (orderBy is not null) return await orderBy(query).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

        return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public IQueryable<Tentity> Find(Expression<Func<Tentity, bool>> expression, bool enableTracking = false)
    {
        if (!enableTracking) DbTable.AsNoTracking();
        return DbTable.Where(expression);
    }

    public Task<int> CountAsync(Expression<Func<Tentity, bool>>? expression = null)
    {
        DbTable.AsNoTracking();

        return expression is not null
            ? DbTable.Where(expression).CountAsync()
            : DbTable.CountAsync();
    }
}
