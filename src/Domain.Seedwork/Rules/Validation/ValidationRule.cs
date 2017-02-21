using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationRule<TEntity> : SpecificationRule<TEntity>, IValidationRule<TEntity>
        where TEntity : class, IEntity
    {
        private readonly string message;
        private readonly string property;

        public ValidationRule(ISpecification<TEntity> rule, string message) : this(rule, message, null)
        {
        }

        public ValidationRule(ISpecification<TEntity> rule, string message, string property) : base(rule)
        {
            Check.Against<ArgumentNullException>(string.IsNullOrEmpty(message), "Please provide a valid non null value for the validationMessage parameter.");

            this.message = message;
            this.property = property;
        }

        public string ValidationMessage
        {
            get { return message; }
        }

        public string ValidationProperty
        {
            get { return property; }
        }

        public bool Validate(TEntity entity)
        {
            return IsSatisfied(entity);
        }
    }
}
