using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class StringPropertyConfiguration<TValidable> : BasePropertyConfiguration<TValidable, string> where TValidable : class
    {
        public StringPropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, string>> expression) : base(contract, expression)
        {}

        public StringPropertyConfiguration<TValidable> IsRequired()
        {
            return IsRequired("The field is required");
        }

        public StringPropertyConfiguration<TValidable> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TValidable, string>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasMinLength(int minLength)
        {
            return HasMinLength(minLength, $"Length must be greater than or equal to {minLength} characters");
        }

        public StringPropertyConfiguration<TValidable> HasMinLength(int minLength, string message)
        {
            Contract.AddRule(new MinLengthRule<TValidable>(Expression, minLength, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasMaxLength(int maxLength)
        {
            return HasMaxLength(maxLength, $"Length must be less than or equal to {maxLength} characters");
        }

        public StringPropertyConfiguration<TValidable> HasMaxLength(int maxLength, string message)
        {
            Contract.AddRule(new MaxLengthRule<TValidable>(Expression, maxLength, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasPattern(string pattern)
        {
            return HasPattern(pattern, "The value does not match the pattern");
        }

        public StringPropertyConfiguration<TValidable> HasPattern(string pattern, string message)
        {
            Contract.AddRule(new PatternRule<TValidable>(Expression, pattern, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> IsCpf()
        {
            return IsCpf("The value is not a valid Cpf");
        }

        public StringPropertyConfiguration<TValidable> IsCpf(string message)
        {
            Contract.AddRule(new CpfRule<TValidable>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> IsCnpj()
        {
            return IsCnpj("The value is not a valid Cnpj");
        }

        public StringPropertyConfiguration<TValidable> IsCnpj(string message)
        {
            Contract.AddRule(new CnpjRule<TValidable>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasRange(int min, int max)
        {
            return HasRange(min, max, $"Length must be between {min} and {max} characters");
        }

        public StringPropertyConfiguration<TValidable> HasRange(int min, int max, string message)
        {
            Contract.AddRule(new StringRangeRule<TValidable>(Expression, min, max, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> IsEmail()
        {
            return IsEmail("The value is not a valid mail address");
        }

        public StringPropertyConfiguration<TValidable> IsEmail(string message)
        {
            Contract.AddRule(new EmailRule<TValidable>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, "Custom rule does not match expectations");
        }

        public StringPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public StringPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public StringPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}