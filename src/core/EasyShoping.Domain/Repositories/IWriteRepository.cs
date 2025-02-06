using EasyShoping.Domain.Entities.Common;
using System.Runtime.InteropServices;

namespace EasyShoping.Domain.Repositories;

public interface IWriteRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
}
