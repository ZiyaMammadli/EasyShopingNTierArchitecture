using EasyShoping.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EasyShoping.Domain.Repositories;

public interface IReadRepository<Tentity> where Tentity : class, IBaseEntity, new()
{
    Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>>? expression = null,
        Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null,
        Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>>? orderBy = null,
        bool enableTracking = false);
    Task<Tentity> GetSingleAsync(Expression<Func<Tentity, bool>> expression,
        Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null,
        bool enableTracking = false);
    Task<List<Tentity>> GetAllByPagingAsync(Expression<Func<Tentity, bool>>? expression = null,
        Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>>? include = null,
        Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>>? orderBy = null,
        bool enableTracking = false, int currentPage = 1, int pageSize = 3);

    IQueryable<Tentity> Find(Expression<Func<Tentity, bool>> expression);
    Task<int> CountAsync(Expression<Func<Tentity, bool>>? expression = null);
}
