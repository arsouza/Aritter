using Aritter.Domain.Seedwork.Aggregates;
using System;

namespace Aritter.Domain.Aggregates.Security
{
    public class UserPassword : Entity
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
    }
}
