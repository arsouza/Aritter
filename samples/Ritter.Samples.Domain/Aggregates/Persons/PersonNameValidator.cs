using Ritter.Domain.Validations;

namespace Ritter.Samples.Domain.Aggregates.Persons
{
    public sealed class PersonNameValidator : EntityValidator<PersonName>
    {
        protected override void Configure(ValidationContract<PersonName> contract)
        {
            contract.Setup(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            contract.Setup(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
