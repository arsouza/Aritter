using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Samples.Domain.Rules;

namespace Ritter.Samples.Domain
{
    public sealed class EmployeeValidator : EntityValidator<Employee>
    {
        public EmployeeValidator()
        {
            AddValidation("IsTransient", EmployeeRules.Transient());
            AddValidation("RequiredFields", EmployeeRules.RequiredFields());
        }

        public ValidationResult ValidateRequiredFields(Employee employee)
        {
            return Validate(employee, "RequiredFields");
        }
    }
}
