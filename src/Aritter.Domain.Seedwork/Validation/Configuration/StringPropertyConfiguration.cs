using Aritter.Domain.Seedwork.Validation.Rules;
using System;

namespace Aritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class StringPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, string>
        where TEntity : class, IValidatableEntity
    {
        public StringPropertyConfiguration(Feature<TEntity> feature, Func<TEntity, string> provider)
            : base(feature, provider)
        {
        }

        public StringPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired(null);
        }

        public StringPropertyConfiguration<TEntity> IsRequired(string invalidMessage)
        {
            Feature.AddRule(new RequiredRule<TEntity, string>(Provider)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength)
        {
            return HasMinLength(minLength, null);
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength, string invalidMessage)
        {
            Feature.AddRule(new MinLengthRule<TEntity>(Provider, minLength)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength)
        {
            return HasMaxLength(maxLength, null);
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength, string invalidMessage)
        {
            Feature.AddRule(new MaxLengthRule<TEntity>(Provider, maxLength)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern)
        {
            return HasPattern(pattern, null);
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern, string invalidMessage)
        {
            Feature.AddRule(new PatternRule<TEntity>(Provider, pattern)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCpf()
        {
            return IsCpf(null);
        }

        public StringPropertyConfiguration<TEntity> IsCpf(string invalidMessage)
        {
            Feature.AddRule(new CpfRule<TEntity>(Provider)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max)
        {
            return HasRange(min, max, null);
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max, string invalidMessage)
        {
            Feature.AddRule(new StringRangeRule<TEntity>(Provider, min, max)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsEmail()
        {
            return IsEmail(null);
        }

        public StringPropertyConfiguration<TEntity> IsEmail(string invalidMessage)
        {
            Feature.AddRule(new EmailRule<TEntity>(Provider)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string invalidMessage)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }
    }
}
