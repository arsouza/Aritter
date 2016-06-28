using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infra.Data.Configuration
{
	internal sealed class UserCredentialMap : EntityBuilder<UserCredential>
	{
		public override void Build(EntityTypeBuilder<UserCredential> builder)
		{
			Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			Property(p => p.PasswordHash)
				.HasMaxLength(50);

			HasRequired(p => p.User)
				.WithRequiredDependent(p => p.Credential);
		}
	}
}
