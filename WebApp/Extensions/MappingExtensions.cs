using AutoMapper;
using WebApp.Business.Contracts;

namespace WebApp.Extensions;

public static class MappingExtensions
{
    private static IMapper? _mapper;

    public static void Configure(IMapper? mapper)
    {
        _mapper = mapper;
    }

    public static T MapTo<T>(this IDto dto) => _mapper!.Map<T>(dto);
}