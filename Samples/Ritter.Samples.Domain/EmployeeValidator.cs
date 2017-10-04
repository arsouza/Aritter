using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Samples.Domain
{
    public sealed class EmployeeValidator : EntityValidator<Employee>
    {
        public EmployeeValidator()
        {
            AddValidation("IsTransient", EmployeeRules.TransientValidation());
            AddValidation("RequiredFields", EmployeeRules.RequiredFieldsValidation());
        }

        public ValidationResult ValidateRequiredFields(Employee employee)
        {
            return Validate(employee, "RequiredFields");
        }
    }
}
