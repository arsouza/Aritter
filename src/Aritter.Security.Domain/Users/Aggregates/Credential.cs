using Aritter.Domain.Seedwork;
using System;

namespace Aritter.Security.Domain.Users.Aggregates
{
    public class Credential : ValueObject<Credential>
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
    }
}
