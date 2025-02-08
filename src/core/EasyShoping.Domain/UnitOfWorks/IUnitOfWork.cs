using EasyShoping.Domain.Entities.Common;
using EasyShoping.Domain.Repositories;

namespace EasyShoping.Domain.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IReadRepository<Tentity> GetReadRepository<Tentity>() where Tentity : class, IBaseEntity, new();
    IWriteRepository<Tentity> GetWriteRepository<Tentity>() where Tentity : class, IBaseEntity, new();
    Task<int> SaveAsync();
    int Save();
}
