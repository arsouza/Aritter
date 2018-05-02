using Ritter.Domain.Validation.Fluent;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Extensions;
using System;

namespace Ritter.Domain.Validation.Rules
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
            Ensure.That<InvalidOperationException>(entity.Is<TValidable>(), $"The entity object must be a instance of '{typeof(TValidable).Name}'");
            return Validate((TValidable)entity);
        }
    }
}
