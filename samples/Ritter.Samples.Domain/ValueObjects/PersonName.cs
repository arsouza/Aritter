using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Configuration;
using System;

namespace Ritter.Samples.Domain.ValueObjects
{
    public class PersonName : ValueObject<PersonName>, IValidable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            SetName(firstName, lastName);
        }

        public IValidationContract<TValidable> SetupValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.Validate(ctx =>
            {
                ctx.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                ctx.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            return contract as IValidationContract<TValidable>;
        }

        public void SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}