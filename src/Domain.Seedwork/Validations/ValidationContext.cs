using Ritter.Domain.Validations.Configurations;
using Ritter.Domain.Validations.Rules;
using Ritter.Infra.Crosscutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations
{
    public sealed class ValidationContext
    {
        private readonly List<IValidationRule> rules;
        private readonly List<Tuple<LambdaExpression, Action<IValidatableEntity, ValidationContext>>> includes;

        public ValidationContext()
        {
            rules = new List<IValidationRule>();
            includes = new List<Tuple<LambdaExpression, Action<IValidatableEntity, ValidationContext>>>();
        }

        public IReadOnlyCollection<IValidationRule> Rules { get { return rules; } }

        public IReadOnlyCollection<Tuple<LambdaExpression, Action<IValidatableEntity, ValidationContext>>> Includes => includes;

        public ObjectPropertyConfiguration<TValidable, TProp> Set<TValidable, TProp>(Expression<Func<TValidable, TProp>> expression)
            where TValidable : class
            where TProp : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new ObjectPropertyConfiguration<TValidable, TProp>(this, expression);
        }

        public CollectionPropertyConfiguration<TValidable> Set<TValidable>(Expression<Func<TValidable, ICollection>> expression)
            where TValidable : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new CollectionPropertyConfiguration<TValidable>(this, expression);
        }

        public StringPropertyConfiguration<TValidable> Set<TValidable>(Expression<Func<TValidable, string>> expression)
            where TValidable : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new StringPropertyConfiguration<TValidable>(this, expression);
        }

        public PrimitivePropertyConfiguration<TValidable, short> Set<TValidable>(Expression<Func<TValidable, short>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, int> Set<TValidable>(Expression<Func<TValidable, int>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, long> Set<TValidable>(Expression<Func<TValidable, long>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ushort> Set<TValidable>(Expression<Func<TValidable, ushort>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, uint> Set<TValidable>(Expression<Func<TValidable, uint>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ulong> Set<TValidable>(Expression<Func<TValidable, ulong>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, byte> Set<TValidable>(Expression<Func<TValidable, byte>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, sbyte> Set<TValidable>(Expression<Func<TValidable, sbyte>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, float> Set<TValidable>(Expression<Func<TValidable, float>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, decimal> Set<TValidable>(Expression<Func<TValidable, decimal>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, double> Set<TValidable>(Expression<Func<TValidable, double>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, DateTime> Set<TValidable>(Expression<Func<TValidable, DateTime>> expression)
            where TValidable : class
        {
            return PropertyInner(expression);
        }

        public void Include<TValidable, TProp>(Expression<Func<TValidable, TProp>> expression)
            where TValidable : class, IValidatableEntity
            where TProp : class, IValidatableEntity
        {
            Ensure.Argument.NotNull(expression, nameof(expression));

            includes.Add(
                new Tuple<LambdaExpression, Action<IValidatableEntity, ValidationContext>>(
                    expression,
                    new Action<IValidatableEntity, ValidationContext>((obj, ctx) => obj.ValidationSetup(ctx))));
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
    }
}
