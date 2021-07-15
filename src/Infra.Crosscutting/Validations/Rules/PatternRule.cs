using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class PatternRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class
    {
        private readonly string pattern;

        public PatternRule(Expression<Func<TValidable, string>> expression, string pattern) : this(expression, pattern, null) { }

        public PatternRule(Expression<Func<TValidable, string>> expression, string pattern, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNullOrEmpty(pattern, nameof(pattern));
            this.pattern = pattern;
        }

        public override bool IsValid(TValidable entity)
        {
            return Regex.IsMatch(Compile(entity), pattern);
        }
    }
}
