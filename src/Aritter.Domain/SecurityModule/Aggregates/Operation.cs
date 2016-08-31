using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Operation : Entity
    {
        public Operation(string name)
            : this()
        {
            Name = name;
        }

        private Operation()
            : base()
        {
        }

        public string Name { get; private set; }

        public int ClientId { get; private set; }

        public virtual Client Client { get; private set; }

        public virtual ICollection<Permission> Permissions { get; private set; } = new HashSet<Permission>();

        public void SetClient(Client client)
        {
            if (client == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid client");
            }

            Client = client;
            ClientId = client.Id;
        }
    }
}
