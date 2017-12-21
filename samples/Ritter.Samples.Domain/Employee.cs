using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Configuration;

namespace Ritter.Samples.Domain
{
    public class Employee : Entity, IValidable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }

        protected Employee() : base() { }

        public Employee(string name, string cpf) : this()
        {
            FirstName = name;
            Cpf = cpf;
        }

        public void ChangeName(string name)
        {
            FirstName = name;
        }

        public IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.ValidateContract(ctx =>
            {
                ctx.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                ctx.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                    .IsCpf();
            });

            return contract as IValidationContract<TValidable>;
        }
    }
}