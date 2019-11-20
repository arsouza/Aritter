using System.Linq;
using System.Text.RegularExpressions;

namespace Ritter.Infra.Crosscutting.Validations
{
    public static class Validations
    {
        public static bool ValidateCnpj(string cnpj)
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

        public static bool ValidateCpf(string cpf)
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
