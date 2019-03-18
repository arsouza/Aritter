using Ritter.Domain;
using Ritter.Infra.Crosscutting.Validations;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public class Name : ValueObject, IValidatable
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

        public void AddValidations(ValidationContext context)
        {
            context.Set<Name>(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            context.Set<Name>(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
