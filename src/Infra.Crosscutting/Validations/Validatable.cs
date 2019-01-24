using System;
using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Validations
{
    public abstract class Validatable : IValidatable
    {
        private List<ValidationError> errors;

        public IReadOnlyCollection<ValidationError> Validations => errors.AsReadOnly();
        public bool Invalid => !Valid;
        public bool Valid => Validations.Count == 0;

        protected Validatable()
        {
            errors = new List<ValidationError>();
        }

        protected void AddValidations(string property, string message)
        {
            AddValidations(new ValidationError(property, message));
        }

        protected void AddValidations(ValidationError error)
        {
            if (!error.IsNull())
                errors.Add(error);
        }

        protected void AddValidations(IEnumerable<ValidationError> errors)
        {
            if (!errors.IsNull())
                this.errors.AddRange(errors);
        }

        protected void AddValidations(Func<ValidationContext, ValidationResult> validationSetup)
        {
            ValidationContext context = new ValidationContext();
            ValidationResult result = validationSetup?.Invoke(context);

            AddValidations(result?.Errors);
        }

        protected void AddValidations(IValidatable item)
        {
            AddValidations(item.Validations);
        }

        protected void AddValidations(params IValidatable[] items)
        {
            foreach (var item in items)
            {
                AddValidations(item);
            }
        }
    }
}
