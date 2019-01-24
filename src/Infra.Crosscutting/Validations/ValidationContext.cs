using Ritter.Infra.Crosscutting.Validations.Configurations;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations
{
    public sealed class ValidationContext
    {
        private readonly List<IValidationRule> rules;
        private readonly List<LambdaExpression> includes;

        public ValidationContext()
        {
            rules = new List<IValidationRule>();
            includes = new List<LambdaExpression>();
        }

        public IReadOnlyCollection<IValidationRule> Rules { get { return rules; } }

        public IReadOnlyCollection<LambdaExpression> Includes => includes;

        public ObjectPropertyConfiguration<TValidable, TProp> Property<TValidable, TProp>(Expression<Func<TValidable, TProp>> expression)
            where TValidable : class
            where TProp : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new ObjectPropertyConfiguration<TValidable, TProp>(this, expression);
        }

        public CollectionPropertyConfiguration<TValidable> Property<TValidable>(Expression<Func<TValidable, ICollection>> expression)
            where TValidable : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new CollectionPropertyConfiguration<TValidable>(this, expression);
        }

        public StringPropertyConfiguration<TValidable> Property<TValidable>(Expression<Func<TValidable, string>> expression)
            where TValidable : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new StringPropertyConfiguration<TValidable>(this, expression);
        }

        public PrimitivePropertyConfiguration<TValidable, short> Property<TValidable>(Expression<Func<TValidable, short>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, int> Property<TValidable>(Expression<Func<TValidable, int>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, long> Property<TValidable>(Expression<Func<TValidable, long>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ushort> Property<TValidable>(Expression<Func<TValidable, ushort>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, uint> Property<TValidable>(Expression<Func<TValidable, uint>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ulong> Property<TValidable>(Expression<Func<TValidable, ulong>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, byte> Property<TValidable>(Expression<Func<TValidable, byte>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, sbyte> Property<TValidable>(Expression<Func<TValidable, sbyte>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, float> Property<TValidable>(Expression<Func<TValidable, float>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, decimal> Property<TValidable>(Expression<Func<TValidable, decimal>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, double> Property<TValidable>(Expression<Func<TValidable, double>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, DateTime> Property<TValidable>(Expression<Func<TValidable, DateTime>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public void Include<TValidable, TProp>(Expression<Func<TValidable, TProp>> expression)
            where TValidable : class, IValidatable
            where TProp : class, IValidatable
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            includes.Add(expression);
        }

        public ValidationResult Validate(object item)
        {
            Ensure.Argument.NotNull(item, nameof(item));
            Ensure.Argument.Is(item.Is<IValidatable>(), $"The type of {nameof(item)} should be a {nameof(IValidatable)}");

            var result = ValidateRules(item);
            result.AddErrors(ValidateIncludes(item));

            return result;
        }

        internal void AddRule<TValidable>(IValidationRule<TValidable> rule)
            where TValidable : class
        {
            Ensure.Argument.NotNull(rule, nameof(rule));
            rules.Add(rule);
        }

        private PrimitivePropertyConfiguration<TValidable, TProp> PropertyInner<TValidable, TProp>(Expression<Func<TValidable, TProp>> expression)
            where TValidable : class
            where TProp : struct
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new PrimitivePropertyConfiguration<TValidable, TProp>(this, expression);
        }

        private ValidationResult ValidateRules(object item)
        {
            var result = new ValidationResult();

            foreach (var rule in rules)
            {
                if (!rule.IsValid(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        private IEnumerable<ValidationError> ValidateIncludes(object item)
        {
            IValidatable entity;

            var errors = includes.SelectMany(include =>
            {
                entity = include
                    .Compile()
                    .DynamicInvoke(item)
                    .As<IValidatable>();

                return entity.Validations;
            });

            return errors;
        }
    }
}
