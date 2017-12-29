using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Configuration;
using Ritter.Samples.Domain.ValueObjects;
using System;
using System.Text.RegularExpressions;

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
            SetCpf(cpf);
        }

        public IValidationContract<TValidable> SetupValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.Validate(ctx =>
            {
                ctx.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                    .IsCpf();

                ctx.Property(e => e.Name.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                ctx.Property(e => e.Name.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
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

        private void SetCpf(string cpf)
        {
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
        }
    }
}