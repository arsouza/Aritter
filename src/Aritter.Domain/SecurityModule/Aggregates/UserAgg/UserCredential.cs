using Aritter.Domain.Seedwork;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class UserCredential : Entity
    {
        public int UserId { get; set; }

        public string PasswordHash { get; set; }

        public DateTime Date { get; set; }

        public DateTime Validity { get; set; }

        public virtual User User { get; set; }

        public int InvalidAttemptsCount { get; set; }

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
