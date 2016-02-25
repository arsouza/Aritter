using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aritter.Infra.Data.SeedWork.Conventions
{
    public sealed class AritterEntityMappingConvention : Convention
    {
        public AritterEntityMappingConvention()
        {
            Properties<int>()
                .Configure(p => p
                .HasColumnType("int"));

            Properties<string>()
                .Configure(p => p
                .HasColumnType("varchar")
                .IsRequired());

            Properties<DateTime>()
                .Configure(p => p
                .HasColumnType("datetime"));

            Properties<bool>()
                .Configure(p => p
                .HasColumnType("bit"));

            Properties<Guid>()
                .Configure(p => p
                .HasColumnType("uniqueidentifier"));
        }
    }
}
