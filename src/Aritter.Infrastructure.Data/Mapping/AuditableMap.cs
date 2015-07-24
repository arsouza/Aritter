using Aritter.Domain;

namespace Aritter.Infrastructure.Data.Mapping
{
	public abstract class AuditableMap<TEntity> : EntityMap<TEntity>
		where TEntity : class, IAuditable
	{
		#region Constructors

		public AuditableMap()
		{
			Property(p => p.Guid)
				.IsRequired();
		}

		#endregion Constructors
	}
}
