using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Web.Security
{
    public class Permission
    {
        public string Application { get; set; }

        public string Resource { get; set; }

        public ICollection<Rule> Authorizations { get; set; } = new List<Rule>();

        public Permission()
        {
        }

        public Permission(string application, string resource)
            : this()
        {
            Application = application;
            Resource = resource;
        }

        public Permission(string application, string resource, params Rule[] authorizations)
            : this(application, resource)
        {
            Application = application;
            Resource = resource;
            Authorizations = authorizations.ToList();
        }
    }
}
