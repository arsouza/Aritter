using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class UserProfile : Entity
    {
        public UserProfile(string fullName)
            : this()
        {
            FullName = fullName;
        }

        private UserProfile()
            : base()
        {
        }

        public string FullName { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
