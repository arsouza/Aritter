using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class PreviousUserCredential : Entity
    {
        public int UserId { get; private set; }

        public string PasswordHash { get; private set; }

        public virtual User User { get; private set; }

        public PreviousUserCredential(User user, UserCredential credential)
        {
            this.UserId = user.Id;
            this.User = user;
            this.PasswordHash = credential.PasswordHash;
        }
    }
}
