using Aritter.Domain.Contracts;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Authentication : Entity
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public AuthenticationState State { get; set; }
        public virtual User User { get; set; }
    }
}
