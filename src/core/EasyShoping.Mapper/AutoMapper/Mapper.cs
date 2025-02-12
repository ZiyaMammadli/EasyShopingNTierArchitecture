using AutoMapper;
using AutoMapper.Internal;
using IMapper = AutoMapper.IMapper;

namespace EasyShoping.Mapper.AutoMapper;

public class Mapper : Application.Interfaces.AutoMapper.IMapper
{
    public static List<TypePair> typePairs = new();
    private IMapper MapperContainer;
    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<TSource, TDestination>(source);
    }

    public List<TDestination> Map<TDestination, TSource>(List<TSource> sources, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<List<TSource>, List<TDestination>>(sources);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);
        return MapperContainer.Map<TDestination>(source);
    }

    public List<TDestination> Map<TDestination>(List<object> sources, string? ignore = null)
    {
        Config<TDestination, List<object>>(5, ignore);
        return MapperContainer.Map<List<TDestination>>(sources);
    }
    protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));
        if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
            return;
        typePairs.Add(typePair);
        var config = new MapperConfiguration(cfg =>
        {
            foreach (var pair in typePairs)
            {
                if (ignore is not null)
                    cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                else
                    cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ReverseMap();
            }
        });
        MapperContainer = config.CreateMapper();
    }
}
