using Ritter.Domain;
using Ritter.Domain.Validations;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Samples.Domain.Aggregates.Persons;
using System;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public class Employee : Entity, IValidatableEntity
    {
        public PersonName Name { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string firstName, string lastName, string cpf) : this()
        {
            Name = new PersonName(firstName, lastName);
            UpdateCpf(cpf);
        }

        public void UpdateCpf(string cpf)
        {
            Ensure.That<ValidationException>(!cpf.IsNullOrEmpty(), "The Cpf is required.");
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
        }

        public void ValidationSetup(ValidationContext context)
        {
            context.Set<Employee>(e => e.Cpf)
                .IsRequired("O CPF é obrigatório")
                .HasMaxLength(11)
                .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .IsCpf();

            context.Include<Employee, PersonName>(e => e.Name);
        }
    }
}
