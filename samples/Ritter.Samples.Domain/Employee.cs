using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Samples.Domain
{
    public class Employee : ValidatableEntity<Employee>
    {
        public const string RequiredFieldsValidation = "RequiredFields";

        public string Name { get; private set; }

        protected Employee()
            : base()
        {

        }

        public Employee(string name)
            : this()
        {
            Name = name;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        protected override void ConfigureFeatures(ValidationFeatureSet<Employee> featureSet)
        {
            featureSet.Feature(RequiredFieldsValidation, f =>
            {
                f.Property(e => e.Name).IsRequired("Faz direito merda!");
            });
        }

        public ValidationResult ValidateRequiredFields()
        {
            return Validate(RequiredFieldsValidation);
        }
    }
}
