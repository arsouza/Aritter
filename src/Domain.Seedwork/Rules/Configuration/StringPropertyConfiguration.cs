using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Configuration
{
    public sealed class StringPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, string>
        where TEntity : class
    {
        public StringPropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, string>> expression)
            : base(feature, expression)
        {
        }

        public StringPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired(null);
        }

        public StringPropertyConfiguration<TEntity> IsRequired(string message)
        {
            Feature.AddRule(new RequiredRule<TEntity, string>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength)
        {
            return HasMinLength(minLength, null);
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength, string message)
        {
            Feature.AddRule(new MinLengthRule<TEntity>(Expression, minLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength)
        {
            return HasMaxLength(maxLength, null);
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength, string message)
        {
            Feature.AddRule(new MaxLengthRule<TEntity>(Expression, maxLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern)
        {
            return HasPattern(pattern, null);
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern, string message)
        {
            Feature.AddRule(new PatternRule<TEntity>(Expression, pattern, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCpf()
        {
            return IsCpf(null);
        }

        public StringPropertyConfiguration<TEntity> IsCpf(string message)
        {
            Feature.AddRule(new CpfRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max)
        {
            return HasRange(min, max, null);
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max, string message)
        {
            Feature.AddRule(new StringRangeRule<TEntity>(Expression, min, max, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsEmail()
        {
            return IsEmail(null);
        }

        public StringPropertyConfiguration<TEntity> IsEmail(string message)
        {
            Feature.AddRule(new EmailRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }
    }
}
