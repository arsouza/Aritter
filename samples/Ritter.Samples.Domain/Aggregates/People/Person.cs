using Ritter.Domain;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public class Person : Entity
    {
        public Name Name { get; private set; }
        public Document Cpf { get; private set; }

        protected Person()
            : base()
        {
        }

        public Person(Name name, Document cpf)
            : this()
        {
            Name = name;
            Cpf = cpf;
        }

        public static Person CreatePerson(string firstName, string lastName, string cpf)
        {
            return new Person(
                Name.CreateName(firstName, lastName),
                Document.CreateCpf(cpf));
        }
    }
}
