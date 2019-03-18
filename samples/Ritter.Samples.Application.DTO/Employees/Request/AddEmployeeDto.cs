using Ritter.Infra.Crosscutting.Validations;

namespace Ritter.Samples.Application.DTO.Employees.Request
{
    public class AddEmployeeDto : IValidatable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public void AddValidations(ValidationContext context)
        {
            context.Set<AddEmployeeDto>(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(50);

            context.Set<AddEmployeeDto>(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            context.Set<AddEmployeeDto>(e => e.Cpf)
                .IsRequired("O CPF é obrigatório")
                .HasMaxLength(11)
                .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .IsCpf();
        }
    }
}
