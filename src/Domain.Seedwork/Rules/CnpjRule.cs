using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class CnpjRule<TEntity> : PropertyRule<TEntity, string>
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
            return ValidaCnpj(Compile(entity));
        }

        public bool ValidaCnpj(string cnpjValidar)
        {
            string cnpj = cnpjValidar;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
