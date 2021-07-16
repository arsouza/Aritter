using FluentValidation;
using FluentValidation.Validators;

namespace Ritter.Infra.Crosscutting.Validations.Validators
{
    public class CpfValidator<T> : PropertyValidator<T, string>, IPropertyValidator
    {
        public override bool IsValid(ValidationContext<T> context, string cnpj) => Document.IsValidCpf(cnpj);

        public override string Name => "CpfValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "O Cpf informado não é válido";
    }
}
