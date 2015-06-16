using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserMap : EntityMap<User>
	{
		public UserMap()
		{
			this.Property(p => p.Username)
				.HasMaxLength(100)
				.HasUniqueIndex("UQ_UserUsername")
				.IsRequired();

			this.Property(p => p.Password)
				.HasMaxLength(100)
				.IsRequired();

			this.Property(p => p.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			this.Property(p => p.LastName)
				.HasMaxLength(100)
				.IsOptional();

			this.Property(p => p.SecurityToken)
				.IsOptional();

			this.Property(p => p.MailAddress)
				.HasMaxLength(255)
				.HasUniqueIndex("UQ_UserMailAddress")
				.IsRequired();
		}
	}
}
