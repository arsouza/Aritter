using Ritter.Domain;

namespace Ritter.Samples.Domain.Shared
{
    public class PersonName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
