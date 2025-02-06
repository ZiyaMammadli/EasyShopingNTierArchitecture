using EasyShoping.Domain.Entities.Common;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace EasyShoping.Domain.Repositories;

public interface IGenericRepository<Tentity> where Tentity : class, IBaseEntity,new()
{
    Task InsertAsync(Tentity entity);
    Task CommitAsync();
    Task<Tentity> DeleteAsync(Tentity tentity);
    List<Tentity> GetAllAsync(Expression<Func<Tentity, bool>> expression, params string[] include);
    Tentity GetSingleAsync(Expression<Func<Tentity, bool>> expression, params string[] include);
    Tentity GetByIdAsync(int id);
}
