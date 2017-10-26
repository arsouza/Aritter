using System.Collections.Generic;
using System.Linq;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public sealed class ValidationResult
    {
        public ValidationResult(params ValidationError[] errors)
        {
            Errors = errors.ToList();
        }

        public bool IsValid => Errors.Count == 0;

        public ICollection<ValidationError> Errors { get; } = new List<ValidationError>();

        public void AddError(ValidationError error)
        {
            Errors.Add(error);
        }

        public void AddError(string message)
        {
            Errors.Add(new ValidationError(message));
        }

        public void AddError(string property, string message)
        {
            Errors.Add(new ValidationError(property, message));
        }

        internal void Append(ValidationResult appendResult)
        {
            foreach (var error in appendResult.Errors)
                AddError(error.Property, error.Message);
        }
    }
}
