using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class UserCredential : Entity
    {
        public int UserId { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Validity { get; private set; }
        public virtual User User { get; private set; }
        public int InvalidAttemptsCount { get; private set; }

        private UserCredential()
        {
        }

        public UserCredential(string passwordHash)
            : this(0, passwordHash)
        {
        }

        public UserCredential(int userId, string passwordHash)
        {
            UserId = userId;
            PasswordHash = Encrypter.Encrypt(passwordHash);
            Date = DateTime.Now;
            GenerateIdentity();
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
