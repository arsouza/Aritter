using Aritter.Domain.Aggregates;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class AuthenticationMap : EntityMap<Authentication>
	{
		public AuthenticationMap()
		{
			Property(p => p.UserName)
				.HasMaxLength(20)
				.IsOptional();

			Property(p => p.State)
				.IsRequired();

			HasOptional(p => p.User)
				.WithMany(p => p.Authentications)
				.HasForeignKey(p => p.UserId);
		}
	}
}
