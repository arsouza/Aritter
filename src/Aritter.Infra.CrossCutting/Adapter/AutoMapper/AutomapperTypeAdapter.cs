using AutoMapper;

namespace Aritter.Infra.CrossCutting.Adapter.AutoMapper
{
	public class AutomapperTypeAdapter : ITypeAdapter
	{
		private readonly IMapper mapper;

		#region Constructors

		public AutomapperTypeAdapter(MapperConfiguration configuration)
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