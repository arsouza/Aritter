using AutoMapper;
using System;

namespace Aritter.Application.DTO.Mapping
{
    public static class Mapper
    {
        public static IMapper CreateMapper(Action<IMapperConfiguration> configure)
        {
            var config = new MapperConfiguration(configure);
            return config.CreateMapper();
        }

        public static IMapper CreateMapper<TSource, TDest>()
        {
            return CreateMapper(cfg =>
            {
                cfg.CreateMap<TSource, TDest>();
            });
        }

        public static IMapper CreateMapper<TProfile>() where TProfile : Profile, new()
        {
            return CreateMapper(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });
        }
    }
}
