using System;
using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public class Authentication : Entity
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public AuthenticationState State { get; set; }
        public virtual User User { get; set; }

        public void ChangeState(AuthenticationState state)
        {
            State = state;
        }
    }
}
