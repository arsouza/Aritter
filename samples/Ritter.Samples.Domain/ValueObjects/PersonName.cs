using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Configuration;
using System;

namespace Ritter.Samples.Domain.ValueObjects
{
    public class PersonName : ValueObject<PersonName>, IValidable<PersonName>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            SetName(firstName, lastName);
        }

        public void SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetupValidation(ValidationContract<PersonName> contract)
        {
            contract.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            contract.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }

        public void SetupValidation(ValidationContract contract)
        {
            SetupValidation((ValidationContract<PersonName>)contract);
        }
    }
}
