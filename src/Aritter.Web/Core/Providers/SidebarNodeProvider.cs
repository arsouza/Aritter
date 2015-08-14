using Aritter.Application.Managers;
using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Configuration;
using Aritter.Infrastructure.Extensions;
using Aritter.Infrastructure.Injection;
using MvcSiteMapProvider;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Aritter.Web.Core.Providers
{
	public class SidebarNodeProvider : DynamicNodeProviderBase
	{
		private readonly IResourceManager resourceManager;
		private readonly IUserManager userManager;

		private readonly IIdentity currentUser;

		public SidebarNodeProvider()
		{
			resourceManager = DependencyProvider.Get<IResourceManager>();
			userManager = DependencyProvider.Get<IUserManager>();

			currentUser = ApplicationSettings.CurrentUser;
		}

		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
		{
			var resources = resourceManager.GetAll();
			var permissions = userManager.GetMenus(currentUser.GetId());

			var dynamicNodes = new List<DynamicNode>();

			foreach (var resource in resources.Where(p => p.Type == ResourceType.Menu))
			{
				var parentNode = new DynamicNode
				{
					Clickable = false,
					Description = resource.Description,
					ImageUrl = resource.Icon,
					Key = resource.Id.ToString(),
					Title = resource.Title,
					Action = null,
					Controller = null,
					Area = null,
					Order = resource.Order,
					ParentKey = null
				};

				var children = GetChildrenNodes(resource.Id, resources, permissions);

				if (!children.Any())
					continue;

				dynamicNodes.Add(parentNode);
				dynamicNodes.AddRange(children);
			}

			return dynamicNodes;
		}

		private IEnumerable<DynamicNode> GetChildrenNodes(int parentId, IEnumerable<Resource> resources, IEnumerable<Resource> permissions)
		{
			var children = new List<DynamicNode>();

			foreach (var child in resources.Where(p => p.ParentId == parentId && permissions.Any(x => x.Id == p.Id)))
			{
				var childNode = new DynamicNode
				{
					Clickable = !resources.Any(p => p.ParentId == child.Id && permissions.Any(x => x.Id == p.Id)),
					Description = child.Description,
					ImageUrl = child.Icon,
					Key = child.Id.ToString(),
					Title = child.Title,
					Action = child.Action,
					Controller = child.Controller,
					Area = child.Area,
					Order = child.Order,
					ParentKey = parentId.ToString()
				};

				children.Add(childNode);

				if (!resources.Any(p => p.ParentId == child.Id))
					continue;

				var childrenNodes = GetChildrenNodes(child.Id, resources, permissions);

				if (childrenNodes.Any())
					children.AddRange(childrenNodes);
			}

			return children;
		}
	}
}