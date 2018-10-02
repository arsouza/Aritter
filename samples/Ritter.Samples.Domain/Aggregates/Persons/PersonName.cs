using Ritter.Domain;
using Ritter.Infra.Crosscutting.Validations;

namespace Ritter.Samples.Domain.Aggregates.Persons
{
    public class PersonName : ValueObject, IValidatableEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void ValidationSetup(ValidationContext context)
        {
            context.Set<PersonName>(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            context.Set<PersonName>(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
