using Aritter.Domain.Contracts;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Resource : Entity
    {
        public ResourceType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public virtual Resource Parent { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Resource> Children { get; set; }

        public void AddChild(Resource resource)
        {
            if (!Children.Contains(resource))
            {
                Children.Add(resource);
            }
        }
    }
}
