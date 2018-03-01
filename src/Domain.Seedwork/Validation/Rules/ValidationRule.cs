using System;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public abstract class ValidationRule<TValidable> : IValidationRule<TValidable> where TValidable : class, IValidable<TValidable>
    {
        protected ValidationRule(string property, string message) : this(message)
        {
            Property = property;
        }

        protected ValidationRule(string message)

        {
            Message = message;
        }

        public string Message { get; protected set; }
        public string Property { get; protected set; }

        public abstract bool Validate(TValidable entity);

        public bool Validate(object entity)
        {
            if (!(entity is TValidable))
                throw new InvalidOperationException("The entity object must be a instance of TValidable");

            return Validate((TValidable)entity);
        }
    }
}
