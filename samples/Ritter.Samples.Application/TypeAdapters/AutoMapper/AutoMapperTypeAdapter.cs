using AutoMapper;
using Ritter.Infra.Crosscutting.TypeAdapter;
using Ritter.Samples.Application.TypeAdapters.AutoMapper.Profiles;

namespace Ritter.Samples.Application.TypeAdapters.AutoMapper
{
    public sealed class AutoMapperTypeAdapter : ITypeAdapter
    {
        public AutoMapperTypeAdapter()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToDtoProfile>();
                config.AddProfile<DtoToDomainProfile>();
            });
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source)
            where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }
    }
}
