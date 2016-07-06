using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.ModuleAgg
{
    public class Menu : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public Menu Parent { get; set; }
        public ICollection<Menu> Children { get; set; } = new HashSet<Menu>();

        public void AddChild(Menu menu)
        {
            if (!Children.Contains(menu))
            {
                Children.Add(menu);
            }
        }
    }
}
