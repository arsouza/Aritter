using Aritter.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserPasswordPolicyMap : AuditableMap<UserPasswordPolicy>
	{
		public UserPasswordPolicyMap()
		{
			Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			Property(p => p.RequireLength)
				.IsRequired();

			Property(p => p.RequireUppercase)
				.IsRequired();

			Property(p => p.RequireLowercase)
				.IsRequired();

			Property(p => p.RequireNonLetterOrDigit)
				.IsRequired();

			Property(p => p.RequireDigit)
				.IsRequired();

			HasRequired(p => p.UserPolicy)
				.WithRequiredDependent(p => p.UserPasswordPolicy);
		}
	}
}
