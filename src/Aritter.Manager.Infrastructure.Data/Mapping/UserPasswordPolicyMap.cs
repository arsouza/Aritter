using Aritter.Manager.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserPasswordPolicyMap : EntityMap<UserPasswordPolicy>
	{
		public UserPasswordPolicyMap()
		{
			this.Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			this.Property(p => p.RequiredMinimumLength)
				.IsRequired();

			this.Property(p => p.RequiredMaximumLength)
				.IsOptional();

			this.Property(p => p.RequiredUppercase)
				.IsRequired();

			this.Property(p => p.RequiredLowercase)
				.IsRequired();

			this.Property(p => p.RequiredNonLetterOrDigit)
				.IsRequired();

			this.Property(p => p.RequiredDigit)
				.IsRequired();

			this.HasRequired(p => p.UserPolicy)
				.WithRequiredDependent(p => p.UserPasswordPolicy);
		}
	}
}
