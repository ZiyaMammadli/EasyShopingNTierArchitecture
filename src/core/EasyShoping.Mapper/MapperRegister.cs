using EasyShoping.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Mapper;

public static class MapperRegister
{
    public static void AddCustomMapperRegister(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
}
