using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class CpfRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class
    {
        public CpfRule(Expression<Func<TValidable, string>> expression) : this(expression, null) { }

        public CpfRule(Expression<Func<TValidable, string>> expression, string message) : base(expression, message) { }

        public override bool IsValid(TValidable entity)
        {
            string cpf = Compile(entity);
            return Validations.ValidateCpf(cpf);
        }
    }
}
