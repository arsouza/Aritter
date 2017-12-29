using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Configuration;
using Ritter.Samples.Domain.ValueObjects;
using System;

namespace Ritter.Samples.Domain
{
    public class Employee : Entity, IValidable
    {
        public PersonName Name { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string firstName, string lastName, string cpf) : this()
        {
            Identify(firstName, lastName);
            Cpf = cpf;
        }

        public IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.ValidateContract(ctx =>
            {
                ctx.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                    .IsCpf();
            });

            return contract as IValidationContract<TValidable>;
        }

        public void Identify(string firstName, string lastName)
        {
            if (Name == null)
                Name = new PersonName(firstName, lastName);
            else
                Name.SetName(firstName, lastName);
        }
    }
}