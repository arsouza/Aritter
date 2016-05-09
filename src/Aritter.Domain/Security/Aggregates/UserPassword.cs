using Aritter.Domain.Seedwork.Aggregates;
using System;
using Aritter.Domain.Security.Aggregates.Users;

namespace Aritter.Domain.Security.Aggregates
{
    public class UserPassword : Entity
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
    }
}
