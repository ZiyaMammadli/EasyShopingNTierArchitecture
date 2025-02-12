namespace EasyShoping.Application.Interfaces.AutoMapper;

public interface IMapper
{
    TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
    List<TDestination> Map<TDestination, TSource>(List<TSource> sources, string? ignore = null);

    TDestination Map<TDestination>(object source, string? ignore = null);
    List<TDestination>Map<TDestination>(List<Object> sources, string? ignore = null);
}
