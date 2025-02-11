using EasyShoping.Domain.Entities.Common;
using EasyShoping.Application.Repositories;

namespace EasyShoping.Application.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IReadRepository<Tentity> GetReadRepository<Tentity>() where Tentity : class, IBaseEntity, new();
    IWriteRepository<Tentity> GetWriteRepository<Tentity>() where Tentity : class, IBaseEntity, new();
    Task<int> SaveAsync();
    int Save();
}
