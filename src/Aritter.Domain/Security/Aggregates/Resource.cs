using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Resource : Entity
    {
        public string Name { get; set; }
        public ResourceType Type { get; set; }
        public string Description { get; set; }
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
