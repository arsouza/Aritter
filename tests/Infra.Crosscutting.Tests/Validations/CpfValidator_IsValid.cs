using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Xunit;

namespace Infra.Crosscutting.Tests.Validations
{
    public class CpfValidator_IsValid
    {
        [Theory]
        [InlineData("572.039.650-07")]
        [InlineData("57203965007")]
        public void ReturnTrueGivenValidCpf(string cpf)
        {
            var person = new Person { Document = cpf };
            var validator = new PersonCpfValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("111.111.111-11")]
        [InlineData("11111111111")]
        [InlineData("572.039.650-01")]
        [InlineData("57203965001")]
        public void ReturnFalseGivenInvalidCpf(string cpf)
        {
            var person = new Person { Document = cpf };
            var validator = new PersonCpfValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("54.967.301/0001-18")]
        [InlineData("11.111.111/1111-11")]
        [InlineData("54967301000118")]
        [InlineData("11111111111111")]
        public void ReturnFalseGivenValidOrInvalidCnpj(string cnpj)
        {
            var person = new Person { Document = cnpj };
            var validator = new PersonCpfValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
        }
    }

    public class PersonCpfValidator : AbstractValidator<Person>
    {
        public PersonCpfValidator()
        {
            RuleFor(p => p.Document)
                .IsValidCpf()
                .WithMessage("O Cpf informado não é válido");
        }
    }
}
