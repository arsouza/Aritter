using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Rule : Entity
    {
        public Rule(string name)
            : this()
        {
            Name = name;
        }

        public Rule(string name, string description)
            : this(name)
        {
            Description = description;
        }

        private Rule()
            : base()
        {
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

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

        public static Rule CreateRule(string name, Client client)
        {
            var rule = new Rule(name);
            rule.SetClient(client);

            return rule;
        }

        public static Rule CreateRule(string name, string description, Client client)
        {
            var rule = new Rule(name, description);
            rule.SetClient(client);

            return rule;
        }
    }
}
