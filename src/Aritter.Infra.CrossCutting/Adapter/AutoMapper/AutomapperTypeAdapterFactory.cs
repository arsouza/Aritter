using AutoMapper;
using System;
using System.Linq;

namespace Aritter.Infra.CrossCutting.Adapter.AutoMapper
{
	public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
	{
		#region

		private readonly MapperConfiguration configuration;

		#endregion

		#region Constructor

		public AutomapperTypeAdapterFactory()
		{
			var profiles = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(t => t.BaseType == typeof(Profile))
				.Cast<Profile>();

			configuration = new MapperConfiguration(config =>
			{
				config.CreateMissingTypeMaps = true;

				foreach (var profile in profiles)
				{
					config.AddProfile(profile);
				}
			});
		}

		#endregion

		#region ITypeAdapterFactory Members

		public ITypeAdapter Create()
		{
			return new AutomapperTypeAdapter(configuration);
		}

		#endregion
	}

}