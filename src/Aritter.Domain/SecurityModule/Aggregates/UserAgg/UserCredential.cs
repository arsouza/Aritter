using Aritter.Domain.Seedwork;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class UserCredential : Entity
    {
        public string PasswordHash { get; set; }

        public DateTime Date { get; set; }

        public DateTime Validity { get; set; }

        public virtual User User { get; set; }

        public int InvalidAttemptsCount { get; set; }

        public UserCredential()
        {
        }

        public UserCredential(User user, string passwordHash)
        {
            Id = user.Id;
            User = user;
            PasswordHash = passwordHash;
            Date = DateTime.Now;
        }

        public void SetValidity(int days)
        {
            Validity = DateTime.Now.AddDays(days);
        }

        public void Expire()
        {
            SetValidity(-1);
        }

        public void HasInvalidAttemptsCount()
        {
            InvalidAttemptsCount++;
        }

        public void HasValidAttemptsCount()
        {
            InvalidAttemptsCount = 0;
        }
    }
}
