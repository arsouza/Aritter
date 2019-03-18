using Ritter.Domain;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected Name()
            : base()
        {
        }

        public Name(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Name NomeCompleto(string firstName, string lastName)
        {
            return new Name(firstName, lastName);
        }
    }
}
