using Aritter.Domain.Aggregates;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class UserPasswordHistoryMap : EntityMap<UserPasswordHistory>
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
