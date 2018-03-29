using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class EmailRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class, IValidable<TValidable>
    {
        private readonly Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);

        public EmailRule(Expression<Func<TValidable, string>> expression) : this(expression, null) { }

        public EmailRule(Expression<Func<TValidable, string>> expression, string message) : base(expression, message) { }

        public override bool Validate(TValidable entity)
        {
            string email = Compile(entity);

            if (email.IsNullOrEmpty())
                return false;

            return regex.IsMatch(email);
        }
    }
}
