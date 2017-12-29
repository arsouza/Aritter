using Ritter.Domain.Seedwork.Validation.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class ValidationContract<TValidable> : IValidationContract<TValidable> where TValidable : class, IValidable
    {
        private List<IValidationRule<TValidable>> rules;

        internal ValidationContract()
        {
            rules = new List<IValidationRule<TValidable>>();
        }

        public IReadOnlyCollection<IValidationRule<TValidable>> Rules { get { return rules; } }

        public ObjectPropertyConfiguration<TValidable, TProp> Property<TProp>(Expression<Func<TValidable, TProp>> expression) where TProp : class
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new ObjectPropertyConfiguration<TValidable, TProp>(this, expression);
        }

        public CollectionPropertyConfiguration<TValidable> Property(Expression<Func<TValidable, ICollection>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new CollectionPropertyConfiguration<TValidable>(this, expression);
        }

        public StringPropertyConfiguration<TValidable> Property(Expression<Func<TValidable, string>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new StringPropertyConfiguration<TValidable>(this, expression);
        }

        public PrimitivePropertyConfiguration<TValidable, short> Property(Expression<Func<TValidable, short>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, int> Property(Expression<Func<TValidable, int>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, long> Property(Expression<Func<TValidable, long>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ushort> Property(Expression<Func<TValidable, ushort>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, uint> Property(Expression<Func<TValidable, uint>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, ulong> Property(Expression<Func<TValidable, ulong>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, byte> Property(Expression<Func<TValidable, byte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, sbyte> Property(Expression<Func<TValidable, sbyte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, float> Property(Expression<Func<TValidable, float>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, decimal> Property(Expression<Func<TValidable, decimal>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, double> Property(Expression<Func<TValidable, double>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidable, DateTime> Property(Expression<Func<TValidable, DateTime>> expression)
        {
            return PropertyInner(expression);
        }

        internal void AddRule(IValidationRule<TValidable> rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule));

            rules.Add(rule);
        }

        private PrimitivePropertyConfiguration<TValidable, TProp> PropertyInner<TProp>(Expression<Func<TValidable, TProp>> expression) where TProp : struct
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new PrimitivePropertyConfiguration<TValidable, TProp>(this, expression);
        }
    }
}