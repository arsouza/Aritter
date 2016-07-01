using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class UserPreviousCredential : Entity
    {
        public int UserId { get; set; }

        public string PasswordHash { get; set; }

        public virtual User User { get; set; }

        public UserPreviousCredential(User user, UserCredential credential)
        {
            this.UserId = user.Id;
            this.User = user;
            this.PasswordHash = credential.PasswordHash;
        }
    }
}
