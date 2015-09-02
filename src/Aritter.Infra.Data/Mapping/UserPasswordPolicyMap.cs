using Aritter.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class UserPasswordPolicyMap : EntityMap<UserPasswordPolicy>
	{
		public UserPasswordPolicyMap()
		{
			Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			HasRequired(p => p.UserPolicy)
				.WithRequiredDependent(p => p.UserPasswordPolicy);
		}
	}
}
