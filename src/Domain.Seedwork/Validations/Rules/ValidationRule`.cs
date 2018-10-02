using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validations.Rules
{
    public abstract class ValidationRule<TValidable> : ValidationRule, IValidationRule<TValidable>
        where TValidable : class
    {
        protected ValidationRule(string property, string message)
            : base(property, message)
        {
        }

        protected ValidationRule(string message)
            : base(message)
        {
        }

        public abstract bool IsValid(TValidable entity);

        public override bool IsValid(object entity)
        {
            Ensure.That<InvalidOperationException>(entity.Is<TValidable>(), $"The entity object must be a instance of '{typeof(TValidable).Name}'");
            return IsValid((TValidable)entity);
        }


    }
}
