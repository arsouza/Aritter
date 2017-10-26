using System.Collections.Generic;
using System.Linq;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationResult
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

        public static ValidationResult operator +(ValidationResult leftResult, ValidationResult rightResult)
        {
            return new ValidationResult(leftResult.Errors.Union(rightResult.Errors).ToArray());
        }
    }
}
