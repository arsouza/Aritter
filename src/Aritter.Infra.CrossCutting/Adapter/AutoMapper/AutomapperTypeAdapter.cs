using AutoMapper;

namespace Aritter.Infra.Crosscutting.Adapter.AutoMapper
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        private readonly IMapper mapper;

        #region Constructors

        public AutoMapperTypeAdapter(MapperConfiguration configuration)
        {
            mapper = configuration.CreateMapper();
        }

        #endregion

        #region ITypeAdapter Members

        public TTarget Adapt<TSource, TTarget>(TSource source) where TSource : class where TTarget : class, new()
        {
            return mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return mapper.Map<TTarget>(source);
        }

        #endregion
    }

}