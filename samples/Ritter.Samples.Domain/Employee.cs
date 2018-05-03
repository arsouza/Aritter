using Ritter.Domain;
using Ritter.Samples.Domain.Shared;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain
{
    public class Employee : Entity
    {
        public PersonName Name { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string firstName, string lastName, string cpf) : this()
        {
            Name = new PersonName(firstName, lastName);
            SetCpf(cpf);
        }

        private void SetCpf(string cpf)
        {
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
        }
    }
}
