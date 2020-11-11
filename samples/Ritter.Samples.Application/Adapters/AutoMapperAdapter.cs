using AutoMapper;
using Ritter.Infra.Crosscutting.Adapters;

namespace Ritter.Samples.Application.Adapters
{
    public class AutoMapperAdapter : ITypeAdapter
    {
        private readonly IMapper mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return mapper.Map<TTarget>(source);
        }
    }
}
