using Aritter.Domain.Contracts;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class UserPassword : Entity
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
    }
}
