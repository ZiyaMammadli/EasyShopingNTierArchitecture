using EasyShoping.Domain.Entities.Common;

namespace EasyShoping.Application.Repositories;

public interface IWriteRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
}
