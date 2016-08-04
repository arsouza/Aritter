using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class UserProfile : Entity
    {
        public UserProfile(string name)
            : this()
        {
            Name = name;
        }

        private UserProfile()
            : base()
        {
        }

        public string Name { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
