using Ritter.Domain.Seedwork.Validation.Fluent;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class CpfRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class, IValidable<TValidable>
    {
        public CpfRule(Expression<Func<TValidable, string>> expression) : this(expression, null) { }

        public CpfRule(Expression<Func<TValidable, string>> expression, string message) : base(expression, message) { }

        public override bool Validate(TValidable entity)
        {
            string cpf = Compile(entity);
            return ValidateCpf(cpf);
        }

        public bool ValidateCpf(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digit;
            int sum, rest;

            string formatedCpf = Regex.Replace(cpf, "[^0-9]", "");

            if (formatedCpf.Length != 11 || formatedCpf.Distinct().Count() == 1)
                return false;

            tempCpf = formatedCpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;
            digit = digit + rest.ToString();

            return formatedCpf.EndsWith(digit);
        }
    }
}
