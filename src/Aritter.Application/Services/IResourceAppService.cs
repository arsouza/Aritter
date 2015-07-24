using Aritter.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Application.Services
{
	public interface IResourceAppService : IAppService
	{
		IEnumerable<Resource> GetAll();
	}
}