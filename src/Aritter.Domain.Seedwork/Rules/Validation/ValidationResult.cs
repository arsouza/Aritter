using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public bool IsValid => errors.Count == 0;

        public ICollection<ValidationError> Errors
        {
            get
            {
                return errors;
            }
        }

        public void AddError(ValidationError error)
        {
            errors.Add(error);
        }

        public void RemoveError(ValidationError error)
        {
            if (errors.Contains(error))
            {
                errors.Remove(error);
            }
        }
    }
}
