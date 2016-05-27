#region license



#endregion

using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public bool IsValid => errors.Count == 0;

        public IEnumerable<ValidationError> Errors
        {
            get
            {
                foreach (var error in errors)
                {
                    yield return error;
                }
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
