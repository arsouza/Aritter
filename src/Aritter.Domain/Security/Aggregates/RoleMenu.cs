using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates
{
    public class RoleMenu : Entity
    {
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
