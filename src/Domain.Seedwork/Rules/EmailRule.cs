using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class EmailRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        private readonly Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);

        public EmailRule(Expression<Func<TEntity, string>> expression)
            : this(expression, null)
        {
        }

        public EmailRule(Expression<Func<TEntity, string>> expression, string message)
            : base(expression, message)
        {
        }

        public override bool Validate(TEntity entity)
        {
            string email = Compile(entity);

            if (email.IsNullOrEmpty())
                return false;

            return regex.IsMatch(email);
        }
    }
}
