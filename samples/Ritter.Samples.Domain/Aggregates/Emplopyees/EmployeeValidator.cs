using Ritter.Domain.Validations;
using Ritter.Samples.Domain.Aggregates.Persons;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public sealed class EmployeeValidator : EntityValidator<Employee>
    {
        protected override void Configure(ValidationContract<Employee> contract)
        {
            contract.Setup(e => e.Cpf)
                .IsRequired("O CPF é obrigatório")
                .HasMaxLength(11)
                .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .IsCpf();

            contract.Include(p => p.Name, new PersonNameValidator());
        }
    }
}
