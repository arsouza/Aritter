using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Fluent;

namespace Ritter.Samples.Domain.ValueObjects
{
    public class PersonName : ValueObject<PersonName>, IValidable<PersonName>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetupValidation(ValidationContract<PersonName> contract)
        {
            contract.Setup(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            contract.Setup(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }

        public void SetupValidation(ValidationContract contract)
        {
            SetupValidation((ValidationContract<PersonName>)contract);
        }
    }
}
