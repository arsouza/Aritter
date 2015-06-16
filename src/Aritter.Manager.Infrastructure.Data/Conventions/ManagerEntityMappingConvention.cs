using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aritter.Manager.Infrastructure.Data.Conventions
{
	public class AritterEntityMappingConvention : Convention
	{
		public AritterEntityMappingConvention()
		{
			this.Properties<int>()
				.Configure(p => p.HasColumnType("int"));

			this.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			this.Properties<DateTime>()
				.Configure(p => p.HasColumnType("datetime"));

			this.Properties<bool>()
				.Configure(p => p.HasColumnType("bit"));

			this.Properties<Guid>()
				.Configure(p => p.HasColumnType("uniqueidentifier"));
		}
	}
}
