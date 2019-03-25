using Ritter.Infra.Crosscutting.Validations;

namespace Ritter.Samples.Application.DTO.People.Requests
{
    public class AddPersonRequest : Validatable<AddPersonRequest>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public override void AddValidations(ValidationContext<AddPersonRequest> context)
        {
            context.Set(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(50);

            context.Set(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            context.Set(e => e.Cpf)
                .IsRequired("O CPF é obrigatório")
                .HasMaxLength(11)
                .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .IsCpf();
        }
    }
}
