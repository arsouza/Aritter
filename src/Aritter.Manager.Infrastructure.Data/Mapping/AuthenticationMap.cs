using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class AuthenticationMap : EntityMap<Authentication>
	{
		public AuthenticationMap()
		{
			this.Property(p => p.UserId)
				.IsOptional();

			this.Property(p => p.UserName)
				.HasMaxLength(20)
				.IsOptional();

			this.Property(p => p.Date)
				.IsRequired();

			this.Property(p => p.State)
				.IsRequired();

			this.HasOptional(p => p.User)
				.WithMany(p => p.Authentications)
				.HasForeignKey(p => p.UserId);
		}
	}
}
