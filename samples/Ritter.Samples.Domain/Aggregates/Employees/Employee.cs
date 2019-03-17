using Ritter.Domain;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Samples.Domain.Aggregates.People;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public class Employee : Entity, IValidatable
    {
        public Name Name { get; private set; }
        public Cpf Cpf { get; private set; }

        protected Employee()
            : base()
        {
        }

        public Employee(Name name, Cpf cpf)
            : this()
        {
            Name = name;
            Cpf = cpf;
        }

        public void ValidationSetup(ValidationContext context)
        {
            context.Include<Employee, Name>(e => e.Name);
            context.Include<Employee, Cpf>(e => e.Cpf);
        }
    }
}
