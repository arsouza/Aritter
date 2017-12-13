using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ValidationContract<TEntity> Validate<TEntity>(this ValidationContract<TEntity> contract, Action<ValidationContract<TEntity>> configAction)
            where TEntity : class, IValidable
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            configAction?.Invoke(contract);
            return contract;
        }

        public static ObjectPropertyConfiguration<TEntity, TProp> Property<TEntity, TProp>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new ObjectPropertyConfiguration<TEntity, TProp>(contract, expression);
        }

        public static CollectionPropertyConfiguration<TEntity> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, ICollection>> expression)
            where TEntity : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new CollectionPropertyConfiguration<TEntity>(contract, expression);
        }

        public static StringPropertyConfiguration<TEntity> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, string>> expression)
            where TEntity : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new StringPropertyConfiguration<TEntity>(contract, expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, short> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, short>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, int> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, int>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, long> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, long>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ushort> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, ushort>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, uint> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, uint>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ulong> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, ulong>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, byte> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, byte>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, sbyte> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, sbyte>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, float> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, float>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, decimal> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, decimal>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, double> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, double>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, DateTime> Property<TEntity>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, DateTime>> expression)
            where TEntity : class
        {
            return contract.PropertyInner(expression);
        }

        private static PrimitivePropertyConfiguration<TEntity, TProp> PropertyInner<TEntity, TProp>(this ValidationContract<TEntity> contract, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : struct
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new PrimitivePropertyConfiguration<TEntity, TProp>(contract, expression);
        }
    }
}
