using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates
{
    public class Authorization : Entity
    {
        public int RoleId { get; set; }
        public bool Allowed { get; set; }
        public bool Denied { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}