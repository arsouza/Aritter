using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationFeature<TEntity>
        where TEntity : class
    {
        public ValidationFeature(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public ICollection<ValidationRule<TEntity>> Rules { get; } = new List<ValidationRule<TEntity>>();

        public string Name { get; private set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }

        internal void AddRule(ValidationRule<TEntity> rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule));

            Rules.Add(rule);
        }
    }
}
