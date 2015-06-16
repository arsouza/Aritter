using Aritter.Manager.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Manager.Domain.Services
{
	public interface IResourceDomainService : IDomainService
	{
		IEnumerable<Resource> GetAll();
	}
}
