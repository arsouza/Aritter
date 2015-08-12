using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserMap : EntityMap<User>
	{
		public UserMap()
		{
			Property(p => p.UserName)
				.HasMaxLength(100)
				.HasUniqueIndex("UQ_UserUsername")
				.IsRequired();

			Property(p => p.PasswordHash)
				.HasMaxLength(100)
				.IsRequired();

			Property(p => p.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			Property(p => p.LastName)
				.HasMaxLength(100)
				.IsOptional();

			Property(p => p.SecurityStamp)
				.HasMaxLength(255)
				.IsOptional();

			Property(p => p.Email)
				.HasMaxLength(255)
				.HasUniqueIndex("UQ_UserMailAddress")
				.IsRequired();

			Property(p => p.EmailConfirmed)
				.IsRequired();

			Property(p => p.TwoFactorEnabled)
				.IsRequired();
		}
	}
}
