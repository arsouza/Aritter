using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class CnpjRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class
    {
        public CnpjRule(Expression<Func<TValidable, string>> expression) : this(expression, null) { }

        public CnpjRule(Expression<Func<TValidable, string>> expression, string message) : base(expression, message) { }

        public override bool IsValid(TValidable entity)
        {
            string cnpj = Compile(entity);
            return Validations.ValidateCnpj(cnpj);
        }
    }
}
