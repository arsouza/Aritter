using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Web.Security
{
    public class Permission
    {
        public string Client { get; set; }

        public string Resource { get; set; }

        public ICollection<Rule> Authorizations { get; set; } = new List<Rule>();

        public Permission()
        {
        }

        public Permission(string client, string resource)
            : this()
        {
            Client = client;
            Resource = resource;
        }

        public Permission(string client, string resource, params Rule[] authorizations)
            : this(client, resource)
        {
            Client = client;
            Resource = resource;
            Authorizations = authorizations.ToList();
        }
    }
}
