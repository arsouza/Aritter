using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserMap : EntityMap<User>
	{
		public UserMap()
		{
			Property(p => p.Username)
				.HasMaxLength(100)
				.HasUniqueIndex("UQ_UserUsername")
				.IsRequired();

			Property(p => p.Password)
				.HasMaxLength(100)
				.IsRequired();

			Property(p => p.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			Property(p => p.LastName)
				.HasMaxLength(100)
				.IsOptional();

			Property(p => p.SecurityToken)
				.IsOptional();

			Property(p => p.MailAddress)
				.HasMaxLength(255)
				.HasUniqueIndex("UQ_UserMailAddress")
				.IsRequired();
		}
	}
}
