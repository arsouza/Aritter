using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates
{
    public class UserPasswordPolicy : Entity
    {
        public int RequireLength { get; set; }
        public int RequireNonLetterOrDigit { get; set; }
        public int RequireDigit { get; set; }
        public int RequireLowercase { get; set; }
        public int RequireUppercase { get; set; }
        public virtual UserPolicy UserPolicy { get; set; }
    }
}