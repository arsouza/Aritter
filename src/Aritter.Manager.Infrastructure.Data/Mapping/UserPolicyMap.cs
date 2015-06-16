using Aritter.Manager.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserPolicyMap : EntityMap<UserPolicy>
	{
		public UserPolicyMap()
		{
			this.Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			this.Property(p => p.MaximumLoginAttempts)
				.IsRequired();

			this.Property(p => p.MinimumPasswordAge)
				.IsRequired();

			this.Property(p => p.MaximumLoginAttempts)
				.IsRequired();

			this.Property(p => p.EnforcePasswordHistory)
				.IsRequired();

			this.HasRequired(p => p.UserPasswordPolicy)
				.WithRequiredPrincipal(p => p.UserPolicy);
		}
	}
}
