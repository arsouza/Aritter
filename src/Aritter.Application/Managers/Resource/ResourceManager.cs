using Aritter.Domain.Aggregates;
using Aritter.Domain.Services;
using System;
using System.Collections.Generic;

namespace Aritter.Application.Managers
{
	public class ResourceManager : ApplicationManager, IResourceManager
	{
		private readonly IResourceDomainService resourceDomainService;

		public ResourceManager(IResourceDomainService resourceDomainService)
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