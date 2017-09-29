using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Samples.Domain.Rules;

namespace Ritter.Samples.Domain
{
    public sealed class EmployeeValidator : EntityValidator<Employee>
    {
        public ValidationResult ValidateNewEmployee(Employee employee)
        {
            RemoveValidations();
            AddValidation("NameIsRequired", new RequiredEmployeeNameRule());

            return Validate(employee);
        }
    }
}
