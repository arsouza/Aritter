using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ValidationContext<TEntity> Validate<TEntity>(this ValidationContext<TEntity> context, Action<ValidationContext<TEntity>> configAction)
            where TEntity : class, IValidable
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            configAction?.Invoke(context);
            return context;
        }

        public static ObjectPropertyConfiguration<TEntity, TProp> Property<TEntity, TProp>(this ValidationContext<TEntity> context, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : class
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new ObjectPropertyConfiguration<TEntity, TProp>(context, expression);
        }

        public static CollectionPropertyConfiguration<TEntity> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, ICollection>> expression)
            where TEntity : class
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new CollectionPropertyConfiguration<TEntity>(context, expression);
        }

        public static StringPropertyConfiguration<TEntity> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, string>> expression)
            where TEntity : class
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new StringPropertyConfiguration<TEntity>(context, expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, short> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, short>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, int> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, int>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, long> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, long>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ushort> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, ushort>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, uint> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, uint>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ulong> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, ulong>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, byte> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, byte>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, sbyte> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, sbyte>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, float> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, float>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, decimal> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, decimal>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, double> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, double>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, DateTime> Property<TEntity>(this ValidationContext<TEntity> context, Expression<Func<TEntity, DateTime>> expression)
            where TEntity : class
        {
            return context.PropertyInner(expression);
        }

        private static PrimitivePropertyConfiguration<TEntity, TProp> PropertyInner<TEntity, TProp>(this ValidationContext<TEntity> context, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : struct
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new PrimitivePropertyConfiguration<TEntity, TProp>(context, expression);
        }
    }
}
