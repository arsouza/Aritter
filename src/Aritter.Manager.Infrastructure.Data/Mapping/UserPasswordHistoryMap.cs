using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserPasswordHistoryMap : EntityMap<UserPasswordHistory>
	{
		public UserPasswordHistoryMap()
		{
			this.Property(p => p.UserId)
				.IsRequired();

			this.Property(p => p.Password)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.Date)
				.IsRequired();

			this.HasRequired(p => p.User)
				.WithMany(p => p.PasswordHistory)
				.HasForeignKey(p => p.UserId);
		}
	}
}
