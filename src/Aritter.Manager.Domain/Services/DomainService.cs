using System;

namespace Aritter.Manager.Domain.Services
{
	public abstract class DomainService : IDomainService
	{
		#region Attributes

		protected readonly IRepository repository;

		#endregion Attributes

		#region Constructors

		protected DomainService(IRepository repository)
		{
			if (repository == null)
				throw new ArgumentNullException("repository");

			this.repository = repository;
		}

		#endregion Constructors
	}
}
