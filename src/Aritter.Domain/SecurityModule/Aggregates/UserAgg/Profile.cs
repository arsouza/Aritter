using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class Profile : Entity
    {
        public Profile(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private Profile()
            : base()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual User User { get; set; }
    }
}
