using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class EmailRule<T> : GenericRule<T, string>
    {
        private readonly Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);

        public EmailRule(Expression<Func<T, string>> expression) : base(expression)
        {
        }

        public EmailRule(Func<T, string> provider) : base(provider)
        {
        }

        public override bool Validate(Func<T> source)
        {
            string email = provider(source());
            
            if(string.IsNullOrEmpty(email))
            {
                return false;
            }
            return regex.IsMatch(email);
        }
    }
}
