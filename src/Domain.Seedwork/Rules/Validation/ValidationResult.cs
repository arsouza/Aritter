using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;

        public ICollection<ValidationError> Errors { get; } = new List<ValidationError>();

        public void AddError(ValidationError error)
        {
            Errors.Add(error);
        }

        public void RemoveError(ValidationError error)
        {
            if (Errors.Contains(error))
                Errors.Remove(error);
        }
    }
}
