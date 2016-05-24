using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class PatternRule<T> : GenericRule<T, string>
    {
        private readonly string pattern;

        public PatternRule(Expression<Func<T, string>> expression, string pattern)
            : base(expression)
        {
            this.pattern = pattern;
        }

        public PatternRule(Func<T, string> provider, string pattern)
            : base(provider)
        {
            this.pattern = pattern;
        }

        public override bool Validate(Func<T> source)
        {
            return Regex.IsMatch(provider(source()), pattern);
        }
    }
}
