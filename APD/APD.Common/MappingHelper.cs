using AutoMapper;

namespace APD.Common;

public static class MappingHelper
{
    public static IEnumerable<T> MapEnumerable<T>(this IMapper mapper, IEnumerable<object> entities)
    {
        return entities.Select(x => mapper.Map<T>(x));
    }
}