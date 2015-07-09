using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserPasswordHistoryMap : EntityMap<UserPasswordHistory>
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
