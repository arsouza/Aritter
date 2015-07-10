using System.Collections.Generic;
using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Application.Services
{
	public interface IResourceAppService : IAppService
	{
		IEnumerable<Resource> GetAll();
	}
}