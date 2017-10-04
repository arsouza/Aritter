using Ritter.Domain.Seedwork.Specs;
using Ritter.Infra.Crosscutting.Exceptions;
using System;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationRule<TEntity> : SpecificationRule<TEntity>, IValidationRule<TEntity>
        where TEntity : class
    {
        private readonly string message;
        private readonly string property;

        public ValidationRule(ISpecification<TEntity> rule, string message)
            : this(rule, message, null)
        {
        }

        public ValidationRule(ISpecification<TEntity> rule, string message, string property)
            : base(rule)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("Please provide a valid non null value for the validationMessage parameter.");

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
