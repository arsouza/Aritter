using Aritter.Domain.Aggregates;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class AuthenticationMap : EntityMap<Authentication>
	{
		public AuthenticationMap()
		{
			Property(p => p.UserId)
				.IsOptional();

			Property(p => p.UserName)
				.HasMaxLength(20)
				.IsOptional();

			Property(p => p.Date)
				.IsRequired();

			Property(p => p.State)
				.IsRequired();

			HasOptional(p => p.User)
				.WithMany(p => p.Authentications)
				.HasForeignKey(p => p.UserId);
		}
	}
}
