using Aritter.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Application.Managers
{
	public interface IResourceManager : IApplicationManager
	{
		IEnumerable<Resource> GetAll();
	}
}