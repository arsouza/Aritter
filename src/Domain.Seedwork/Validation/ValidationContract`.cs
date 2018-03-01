using Ritter.Domain.Seedwork.Validation.Configuration;
using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class ValidationContract<TValidable> : ValidationContract where TValidable : class, IValidable<TValidable>
    {
        public ValidationContract() : base()
        {
        }

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

        public void Include<TIncludeType, TProp>(Expression<Func<TIncludeType, TProp>> expression) where TIncludeType : class, IValidable<TIncludeType> where TProp : class
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            string property = expression.GetPropertyName();
            Type type = typeof(TIncludeType);

            includes.Add(new KeyValuePair<Type, LambdaExpression>(type, expression));
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, string>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            string property = expression.GetPropertyName();
            Type type = typeof(TIncludeType);

            includes.Add(new KeyValuePair<Type, LambdaExpression>(type, expression));
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, short>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, int>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, long>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, ushort>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, uint>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, ulong>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, byte>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, sbyte>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, float>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, decimal>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, double>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
        }

        public void Include<TIncludeType>(Expression<Func<TIncludeType, DateTime>> expression) where TIncludeType : class, IValidable<TIncludeType>
        {
            IncludeInner(expression);
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

        private void IncludeInner<TIncludeType, TProp>(Expression<Func<TIncludeType, TProp>> expression) where TIncludeType : class, IValidable<TIncludeType> where TProp : struct
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            string property = expression.GetPropertyName();
            Type type = typeof(TIncludeType);

            includes.Add(new KeyValuePair<Type, LambdaExpression>(type, expression));
        }
    }
}
