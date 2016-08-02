using Aritter.Application.DTO.Profiles.SecurityModule;
using Aritter.Application.DTO.Profiles.SecurityModule.Users;
using Aritter.Infra.Crosscutting.Adapter;
using AutoMapper;

namespace Aritter.Application.Seedwork.Adapter.AutoMapper
{
	public class AutoMapperTypeAdapter : ITypeAdapter
	{
		#region Constructors

		public AutoMapperTypeAdapter()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMissingTypeMaps = true;
				cfg.AddProfile<AuthenticationProfile>();
				cfg.AddProfile<UserProfile>();
			});
		}

		#endregion

		#region ITypeAdapter Members

		public TTarget Adapt<TSource, TTarget>(TSource source)
			where TSource : class
			where TTarget : class, new()
		{
			return Mapper.Map<TSource, TTarget>(source);
		}

		public TTarget Adapt<TTarget>(object source)
			where TTarget : class, new()
		{
			return Mapper.Map<TTarget>(source);
		}

		#endregion
	}

}