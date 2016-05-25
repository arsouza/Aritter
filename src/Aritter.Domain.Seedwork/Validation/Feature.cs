using Aritter.Domain.Seedwork.Validation.Rules;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation
{
    public class Feature<T> where T : class, IValidatableEntity
    {
        private readonly List<Rule<T>> rules;

        public Feature(string name)
        {
            ThrowHelper.ThrowArgumentNullException(name, nameof(name));
            rules = new List<Rule<T>>();
            Name = name;
        }

        public IEnumerable<Rule<T>> Rules
        {
            get
            {
                return rules;
            }
        }

        public string Name
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            set;
        }

        public void AddRule(Rule<T> rule)
        {
            ThrowHelper.ThrowArgumentNullException(rule, nameof(rule));
            rules.Add(rule);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
