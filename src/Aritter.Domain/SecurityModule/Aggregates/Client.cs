using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Client : Entity
    {
        public Client(string name)
            : this()
        {
            Name = name;
        }

        public Client(string name, string description)
            : this(name)
        {
            Description = description;
        }

        private Client()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<Operation> Operations { get; private set; } = new List<Operation>();
        public virtual ICollection<Resource> Resources { get; private set; } = new List<Resource>();
        public virtual ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
        public virtual ICollection<UserClient> UserAccounts { get; private set; } = new List<UserClient>();
    }
}
