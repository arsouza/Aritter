using Aritter.Domain.Seedwork;

namespace Aritter.Domain.Security.Aggregates
{
    public class UserProfile : ValueObject<UserProfile>
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

        public string FullName { get; private set; }

        public int UserId { get; private set; }

        public virtual User User { get; private set; }
    }
}
