using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public class ObjectPropertyConfiguration<TValidable, TProp> : BasePropertyConfiguration<TValidable, TProp>
        where TValidable : class
        where TProp : class
    {
        public ObjectPropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, TProp>> expression)
            : base(context, expression) { }

        public virtual ObjectPropertyConfiguration<TValidable, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public virtual ObjectPropertyConfiguration<TValidable, TProp> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TValidable, TProp>(Expression, message));
            return this;
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Context.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public ObjectPropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}
