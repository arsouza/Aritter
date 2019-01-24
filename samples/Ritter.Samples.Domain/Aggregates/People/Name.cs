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

            AddValidations(context =>
            {
                context.Property<Name>(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                context.Property<Name>(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                return context.Validate(this);
            });
        }
    }
}
