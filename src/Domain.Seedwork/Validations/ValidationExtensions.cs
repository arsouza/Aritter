using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Ritter.Domain.Validations
{
    public static class ValidationExtensions
    {
        public static ValidationResult EnsureValid(this ValidationResult result)
        {
            Ensure.That<ValidationException>(result.IsValid, result.Errors.Join(", "));
            return result;
        }
    }
}
