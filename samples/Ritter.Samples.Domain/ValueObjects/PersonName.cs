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
            FirstName = firstName;
            LastName = lastName;
        }

        public IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.ValidateContract(ctx =>
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
    }
}