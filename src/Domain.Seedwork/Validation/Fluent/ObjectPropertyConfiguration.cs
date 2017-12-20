using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Fluent
{
    public class ObjectPropertyConfiguration<TValidable, TProp> : BasePropertyConfiguration<TValidable, TProp> where TValidable : class, IValidable where TProp : class
    {
        public ObjectPropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression) : base(contract, expression) { }

        public virtual ObjectPropertyConfiguration<TValidable, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public virtual ObjectPropertyConfiguration<TValidable, TProp> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TValidable, TProp>(Expression, message));
            return this;
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}