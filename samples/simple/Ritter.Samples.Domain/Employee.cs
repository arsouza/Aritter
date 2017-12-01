using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Domain.Seedwork.Rules.Validation.Configuration;

namespace Ritter.Samples.Domain
{
    public class Employee : ValidatableEntity<Employee>
    {
        public const string RequiredFieldsValidation = "RequiredFields";

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }

        protected Employee()
            : base()
        {
        }

        public Employee(string name, string cpf)
            : this()
        {
            FirstName = name;
            Cpf = cpf;
        }

        public void ChangeName(string name)
        {
            FirstName = name;
        }

        protected override void OnConfigureFeatures(ValidationFeatureSet<Employee> featureSet)
        {
            featureSet.Feature(RequiredFieldsValidation, f =>
            {
                f.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                f.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                    .IsCpf();
            });
        }

        public ValidationResult ValidateRequiredFields()
        {
            return Validate(RequiredFieldsValidation);
        }
    }
}
