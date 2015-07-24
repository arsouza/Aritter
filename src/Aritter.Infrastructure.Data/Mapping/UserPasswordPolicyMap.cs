using Aritter.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserPasswordPolicyMap : EntityMap<UserPasswordPolicy>
	{
		public UserPasswordPolicyMap()
		{
			Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			Property(p => p.RequiredMinimumLength)
				.IsRequired();

			Property(p => p.RequiredMaximumLength)
				.IsOptional();

			Property(p => p.RequiredUppercase)
				.IsRequired();

			Property(p => p.RequiredLowercase)
				.IsRequired();

			Property(p => p.RequiredNonLetterOrDigit)
				.IsRequired();

			Property(p => p.RequiredDigit)
				.IsRequired();

			HasRequired(p => p.UserPolicy)
				.WithRequiredDependent(p => p.UserPasswordPolicy);
		}
	}
}
