using AutoMapper;
using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Ritter.Samples.Application.Projections
{
    internal sealed class AutoMapperTypeAdapter : ITypeAdapter
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
            => Mapper.Map<TTarget>(source);

        public TTarget Adapt<TTarget>(object source)
            where TTarget : class, new()
            => Mapper.Map<TTarget>(source);
    }
}
