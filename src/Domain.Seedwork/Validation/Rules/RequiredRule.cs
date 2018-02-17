using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class RequiredRule<TValidable, TProp> : PropertyRule<TValidable, TProp> where TValidable : class, IValidable
    {
        public RequiredRule(Expression<Func<TValidable, TProp>> expression) : this(expression, null) { }

        public RequiredRule(Expression<Func<TValidable, TProp>> expression, string message) : base(expression, message) { }

        public override bool Validate(TValidable entity)
        {
            if (typeof(TProp) == typeof(string))
                return !(Compile(entity) as string).IsNullOrEmpty();

            return Compile(entity) != null;
        }
    }
}
