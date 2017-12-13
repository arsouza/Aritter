using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public class ObjectPropertyConfiguration<TEntity, TProp> : BasePropertyConfiguration<TEntity, TProp> where TEntity : class where TProp : class
    {
        public ObjectPropertyConfiguration(ValidationContract<TEntity> contract, Expression<Func<TEntity, TProp>> expression) : base(contract, expression) {}

        public virtual ObjectPropertyConfiguration<TEntity, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public virtual ObjectPropertyConfiguration<TEntity, TProp> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TEntity, TProp>(Expression, message));
            return this;
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasSpecification(ISpecification<TEntity> specification)
        {
            return HasSpecification(specification, null);
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasSpecification(ISpecification<TEntity> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TEntity>(specification, message));
            return this;
        }
    }
}