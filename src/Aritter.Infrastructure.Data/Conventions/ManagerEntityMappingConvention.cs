using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aritter.Infrastructure.Data.Conventions
{
	public class AritterEntityMappingConvention : Convention
	{
		public AritterEntityMappingConvention()
		{
			Properties<int>()
				.Configure(p => p.HasColumnType("int"));

			Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			Properties<DateTime>()
				.Configure(p => p.HasColumnType("datetime"));

			Properties<bool>()
				.Configure(p => p.HasColumnType("bit"));

			Properties<Guid>()
				.Configure(p => p.HasColumnType("uniqueidentifier"));
		}
	}
}
