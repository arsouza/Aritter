#region license



#endregion

using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public bool IsValid { get { return _errors.Count == 0; } }

        public IEnumerable<ValidationError> Errors
        {
            get
            {
                foreach (var error in _errors)
                    yield return error;
            }
        }

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public void RemoveError(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }
    }
}
