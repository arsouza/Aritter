using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class PatternRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        private readonly string pattern;

        public PatternRule(Expression<Func<TEntity, string>> expression, string pattern)
            : this(expression, pattern, null)
        {
        }

        public PatternRule(Expression<Func<TEntity, string>> expression, string pattern, string message)
            : base(expression, message)
        {
            this.pattern = pattern;
        }

        public override bool Validate(TEntity entity)
        {
            return Regex.IsMatch(Compile(entity), pattern);
        }
    }
}
