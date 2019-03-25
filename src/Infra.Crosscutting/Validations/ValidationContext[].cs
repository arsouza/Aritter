using Ritter.Infra.Crosscutting.Validations.Configurations;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations
{
    public sealed class ValidationContext<TValidatable> : ValidationContext where TValidatable : class
    {
        public ValidationContext() : base()
        {
        }

        public ObjectPropertyConfiguration<TValidatable, TProp> Set<TProp>(Expression<Func<TValidatable, TProp>> expression)
            where TProp : class
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new ObjectPropertyConfiguration<TValidatable, TProp>(this, expression);
        }

        public CollectionPropertyConfiguration<TValidatable> Set(Expression<Func<TValidatable, ICollection>> expression)
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new CollectionPropertyConfiguration<TValidatable>(this, expression);
        }

        public StringPropertyConfiguration<TValidatable> Set(Expression<Func<TValidatable, string>> expression)
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new StringPropertyConfiguration<TValidatable>(this, expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, short> Set(Expression<Func<TValidatable, short>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, int> Set(Expression<Func<TValidatable, int>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, long> Set(Expression<Func<TValidatable, long>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, ushort> Set(Expression<Func<TValidatable, ushort>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, uint> Set(Expression<Func<TValidatable, uint>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, ulong> Set(Expression<Func<TValidatable, ulong>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, byte> Set(Expression<Func<TValidatable, byte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, sbyte> Set(Expression<Func<TValidatable, sbyte>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, float> Set(Expression<Func<TValidatable, float>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, decimal> Set(Expression<Func<TValidatable, decimal>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, double> Set(Expression<Func<TValidatable, double>> expression)
        {
            return PropertyInner(expression);
        }

        public PrimitivePropertyConfiguration<TValidatable, DateTime> Set(Expression<Func<TValidatable, DateTime>> expression)
        {
            return PropertyInner(expression);
        }

        private PrimitivePropertyConfiguration<TValidatable, TProp> PropertyInner<TProp>(Expression<Func<TValidatable, TProp>> expression)

            where TProp : struct
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            return new PrimitivePropertyConfiguration<TValidatable, TProp>(this, expression);
        }
    }
}
