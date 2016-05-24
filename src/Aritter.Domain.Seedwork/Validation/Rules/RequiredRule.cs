using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class RequiredRule<T, TProp> : GenericRule<T, TProp> where TProp : class
    {
        public RequiredRule(Expression<Func<T, TProp>> expression) : base(expression)
        {
        }

        public RequiredRule(Func<T, TProp> provider) : base(provider)
        {
        }

        public override bool Validate(Func<T> source)
        {
            if (typeof(TProp) == typeof(string))
            {
                return !string.IsNullOrEmpty(provider(source()) as string);
            }
            return provider(source()) != null;
        }
    }
}
