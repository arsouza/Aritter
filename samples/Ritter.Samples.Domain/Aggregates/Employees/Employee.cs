using Ritter.Domain;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public class Employee : Entity
    {
        public int CpfId { get; private set; }
        public Name Name { get; private set; }
        public Document Cpf { get; private set; }

        protected Employee()
            : base()
        {
        }

        public Employee(Name name, Document cpf)
            : this()
        {
            Name = name;
            Cpf = cpf;
        }
    }
}
