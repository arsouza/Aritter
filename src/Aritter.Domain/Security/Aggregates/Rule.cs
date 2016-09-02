using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
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

        public int ApplicationId { get; private set; }

        public virtual Application Application { get; private set; }

        public virtual ICollection<Permission> Permissions { get; private set; } = new HashSet<Permission>();

        public void SetApplication(Application application)
        {
            if (application == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid application");
            }

            Application = application;
            ApplicationId = application.Id;
        }

        public static Rule CreateRule(string name, Application application)
        {
            var rule = new Rule(name);
            rule.SetApplication(application);

            return rule;
        }

        public static Rule CreateRule(string name, string description, Application application)
        {
            var rule = new Rule(name, description);
            rule.SetApplication(application);

            return rule;
        }
    }
}
