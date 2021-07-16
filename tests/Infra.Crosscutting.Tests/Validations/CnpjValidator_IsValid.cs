using System.Linq;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Xunit;

namespace Infra.Crosscutting.Tests.Validations
{
    public class CnpjValidator_IsValid
    {
        [Theory]
        [InlineData("54967301000118")]
        public void ReturnTrueGivenValidCnpj(string cnpj)
        {
            var person = new Person { Document = cnpj };
            var validator = new PersonCnpjValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("11.111.111/1111-11")]
        [InlineData("11111111111111")]
        public void ReturnFalseGivenInvalidCnpj(string cnpj)
        {
            var person = new Person { Document = cnpj };
            var validator = new PersonCnpjValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors
                .Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.Match(e => e.All(x => x.ErrorMessage == "O Cnpj informado não é válido"));
        }

        [Theory]
        [InlineData("572.039.650-07")]
        [InlineData("57203965007")]
        [InlineData("111.111.111-11")]
        [InlineData("11111111111")]
        [InlineData("572.039.650-01")]
        [InlineData("57203965001")]
        public void ReturnFalseGivenValidOrInvalidCpf(string cnpj)
        {
            var person = new Person { Document = cnpj };
            var validator = new PersonCnpjValidator();

            ValidationResult result = validator.Validate(person);

            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors
                .Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.Match(e => e.All(x => x.ErrorMessage == "O Cnpj informado não é válido"));
        }
    }

    public class PersonCnpjValidator : AbstractValidator<Person>
    {
        public PersonCnpjValidator()
        {
            RuleFor(p => p.Document)
                .IsValidCnpj()
                .WithMessage("O Cnpj informado não é válido");
        }
    }
}
