using Ritter.Domain;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Samples.Domain.Aggregates.Persons;
using System;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public class Employee : Entity
    {
        public PersonName Name { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string firstName, string lastName, string cpf) : this()
        {
            Ensure.That<ValidationException>(!cpf.IsNullOrEmpty(), "The Cpf is required.");

            Name = new PersonName(firstName, lastName);
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
        }
    }
}
