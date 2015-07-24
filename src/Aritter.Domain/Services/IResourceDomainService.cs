using Aritter.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Services
{
	public interface IResourceDomainService : IDomainService
	{
		IEnumerable<Resource> GetAll();
	}
}
