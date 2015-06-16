using Aritter.Manager.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Manager.Domain.Services
{
	public class ResourceDomainService : DomainService, IResourceDomainService
	{
		public ResourceDomainService(IRepository repository)
			: base(repository)
		{
		}

		public IEnumerable<Resource> GetAll()
		{
			var resources = this.repository
				.All<Resource>()
				.Select(p => new Resource
				{
					Description = p.Description,
					Icon = p.Icon,
					Id = p.Id,
					Title = p.Title,
					Action = p.Action,
					Controller = p.Controller,
					Area = p.Area,
					Order = p.Order,
				})
				.ToList();

			return resources;
		}
	}
}
