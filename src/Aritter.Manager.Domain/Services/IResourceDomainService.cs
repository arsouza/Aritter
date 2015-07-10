using System.Collections.Generic;
using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Domain.Services
{
	public interface IResourceDomainService : IDomainService
	{
		IEnumerable<Resource> GetAll();
	}
}
