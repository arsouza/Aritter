using Aritter.Domain.Aggregates;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserPasswordHistoryMap : AuditableMap<UserPasswordHistory>
	{
		public UserPasswordHistoryMap()
		{
			Property(p => p.UserId)
				.IsRequired();

			Property(p => p.Password)
				.HasMaxLength(50)
				.IsRequired();

			Property(p => p.Date)
				.IsRequired();

			HasRequired(p => p.User)
				.WithMany(p => p.PasswordHistory)
				.HasForeignKey(p => p.UserId);
		}
	}
}
