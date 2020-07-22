using Ritter.Infra.Crosscutting.Exceptions;

namespace Ritter.Infra.Crosscutting.Validations
{
    public static class ValidationExtensions
    {
        public static ValidationResult EnsureValidResult(this ValidationResult result)
        {
            if (!(result?.IsValid).GetValueOrDefault())
            {
                throw new BusinessException(string.Join(". ", result?.Errors ?? new[] { new ValidationError("A validação falhou. Por favor consulte o administrador do sistema para mais detalhes") }));
            }

            return result;
        }
    }
}
