using Aritter.Manager.Domain;

namespace Aritter.Manager.Infrastructure.Data.Mapping
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
