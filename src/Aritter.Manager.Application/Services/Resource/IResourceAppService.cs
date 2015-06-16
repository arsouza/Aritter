using Aritter.Manager.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Manager.Application.Services
{
	public interface IResourceAppService : IAppService
	{
		IEnumerable<Resource> GetAll();
	}
}