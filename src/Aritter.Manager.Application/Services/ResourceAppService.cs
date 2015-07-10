using System;
using System.Collections.Generic;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.Services;

namespace Aritter.Manager.Application.Services
{
	public class ResourceAppService : AppService, IResourceAppService
	{
		private readonly IResourceDomainService resourceDomainService;

		public ResourceAppService(IResourceDomainService resourceDomainService)
		{
			if (resourceDomainService == null)
				throw new ArgumentNullException("resourceDomainService");

			this.resourceDomainService = resourceDomainService;
		}

		public IEnumerable<Resource> GetAll()
		{
			var resources = resourceDomainService
				.GetAll();

			return resources;
		}
	}
}