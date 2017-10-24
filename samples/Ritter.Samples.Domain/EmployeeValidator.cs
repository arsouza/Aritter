using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Samples.Domain
{
    public sealed class EmployeeValidator : EntityValidator<Employee>
    {
        public ValidationResult ValidateRequiredFields(Employee employee)
        {
            return Validate(employee, Employee.RequiredFieldsValidation);
        }
    }
}
