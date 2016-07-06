using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.MainAgg
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual User User { get; set; }
    }
}
