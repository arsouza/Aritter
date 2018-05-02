using Ritter.Infra.Crosscutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Validation.Fluent
{
    public sealed class ValidationContract<TValidable> : ValidationContract where TValidable : class, IValidable<TValidable>
    {
        public ValidationContract() : base()
        {
        }

        public ObjectPropertyConfiguration<TValidable, TProp> Setup<TProp>(Expression<Func<TValidable, TProp>> expression) where TProp : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new ObjectPropertyConfiguration<TValidable, TProp>(this, expression);
        }

        public CollectionPropertyConfiguration<TValidable> Setup(Expression<Func<TValidable, ICollection>> expression)
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new CollectionPropertyConfiguration<TValidable>(this, expression);
        }

        public StringPropertyConfiguration<TValidable> Setup(Expression<Func<TValidable, string>> expression)
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new StringPropertyConfiguration<TValidable>(this, expression);
        }

        public PrimitivePropertyConfiguration<TValidable, short> Setup(Expression<Func<TValidable, short>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, int> Setup(Expression<Func<TValidable, int>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, long> Setup(Expression<Func<TValidable, long>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ushort> Setup(Expression<Func<TValidable, ushort>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, uint> Setup(Expression<Func<TValidable, uint>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ulong> Setup(Expression<Func<TValidable, ulong>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, byte> Setup(Expression<Func<TValidable, byte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, sbyte> Setup(Expression<Func<TValidable, sbyte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, float> Setup(Expression<Func<TValidable, float>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, decimal> Setup(Expression<Func<TValidable, decimal>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, double> Setup(Expression<Func<TValidable, double>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, DateTime> Setup(Expression<Func<TValidable, DateTime>> expression)
        {
            return PropertyInner(expression);
        }

        public void Include<TProp>(Expression<Func<TValidable, TProp>> expression) where TProp : class, IValidable<TProp>
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            includes.Add(new KeyValuePair<Type, LambdaExpression>(typeof(TValidable), expression));
        }

        internal void AddRule(IValidationRule<TValidable> rule)
        {
            Ensure.Argument.NotNull(rule, nameof(rule));
            rules.Add(rule);
        }

        private PrimitivePropertyConfiguration<TValidable, TProp> PropertyInner<TProp>(Expression<Func<TValidable, TProp>> expression) where TProp : struct
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new PrimitivePropertyConfiguration<TValidable, TProp>(this, expression);
        }
    }
}
