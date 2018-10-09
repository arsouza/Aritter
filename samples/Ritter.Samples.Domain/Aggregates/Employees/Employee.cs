using Ritter.Domain;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public class Employee : Entity
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

            AddValidations(Name, Cpf);
        }
    }
}
