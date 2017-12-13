using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class StringPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, string> where TEntity : class
    {
        public StringPropertyConfiguration(ValidationContract<TEntity> contract, Expression<Func<TEntity, string>> expression) : base(contract, expression)
        {}

        public StringPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired("The field is required");
        }

        public StringPropertyConfiguration<TEntity> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TEntity, string>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength)
        {
            return HasMinLength(minLength, $"Length must be greater than or equal to {minLength} characters");
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength, string message)
        {
            Contract.AddRule(new MinLengthRule<TEntity>(Expression, minLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength)
        {
            return HasMaxLength(maxLength, $"Length must be less than or equal to {maxLength} characters");
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength, string message)
        {
            Contract.AddRule(new MaxLengthRule<TEntity>(Expression, maxLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern)
        {
            return HasPattern(pattern, "The value does not match the pattern");
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern, string message)
        {
            Contract.AddRule(new PatternRule<TEntity>(Expression, pattern, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCpf()
        {
            return IsCpf("The value is not a valid Cpf");
        }

        public StringPropertyConfiguration<TEntity> IsCpf(string message)
        {
            Contract.AddRule(new CpfRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCnpj()
        {
            return IsCnpj("The value is not a valid Cnpj");
        }

        public StringPropertyConfiguration<TEntity> IsCnpj(string message)
        {
            Contract.AddRule(new CnpjRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max)
        {
            return HasRange(min, max, $"Length must be between {min} and {max} characters");
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max, string message)
        {
            Contract.AddRule(new StringRangeRule<TEntity>(Expression, min, max, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsEmail()
        {
            return IsEmail("The value is not a valid mail address");
        }

        public StringPropertyConfiguration<TEntity> IsEmail(string message)
        {
            Contract.AddRule(new EmailRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, "Custom rule does not match expectations");
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasSpecification(ISpecification<TEntity> specification)
        {
            return HasSpecification(specification, null);
        }

        public StringPropertyConfiguration<TEntity> HasSpecification(ISpecification<TEntity> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TEntity>(specification, message));
            return this;
        }
    }
}