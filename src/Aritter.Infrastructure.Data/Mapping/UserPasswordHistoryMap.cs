using Aritter.Domain.Aggregates;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserPasswordHistoryMap : EntityMap<UserPasswordHistory>
	{
		public UserPasswordHistoryMap()
		{
			Property(p => p.Password)
				.HasMaxLength(50);

			HasRequired(p => p.User)
				.WithMany(p => p.PasswordHistory)
				.HasForeignKey(p => p.UserId);
		}
	}
}
