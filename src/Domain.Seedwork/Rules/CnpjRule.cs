using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public sealed class CnpjRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        public CnpjRule(Expression<Func<TEntity, string>> expression)
            : this(expression, null)
        {
        }

        public CnpjRule(Expression<Func<TEntity, string>> expression, string message)
            : base(expression, message)
        {
        }

        public override bool Validate(TEntity entity)
        {
            string cnpj = Compile(entity);
            return ValidateCnpj(cnpj);
        }

        public bool ValidateCnpj(string cnpj)
        {
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj, digit;
            int sum, rest;

            var formatedCnpj = Regex.Replace(cnpj, "[^0-9]", "");

            if (formatedCnpj.Length != 14 || formatedCnpj.Distinct().Count() == 1)
                return false;

            tempCnpj = formatedCnpj.Substring(0, 12);
            sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

            rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;

            digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

            rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;

            digit = digit + rest.ToString();
            return formatedCnpj.EndsWith(digit);
        }
    }
}
