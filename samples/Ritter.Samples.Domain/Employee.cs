using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Fluent;
using Ritter.Samples.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain
{
    public class Employee : Entity, IValidable<Employee>
    {
        public PersonName Name { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string firstName, string lastName, string cpf) : this()
        {
            Name = new PersonName(firstName, lastName);
            SetCpf(cpf);
        }

        public void SetupValidation(ValidationContract<Employee> contract)
        {
            contract.Setup(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .IsCpf();

            contract.Include<Employee, PersonName>(p => p.Name);
        }

        public void SetupValidation(ValidationContract contract)
        {
            SetupValidation((ValidationContract<Employee>)contract);
        }

        private void SetCpf(string cpf)
        {
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
        }
    }
}
