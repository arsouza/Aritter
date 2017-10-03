using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Domain.Seedwork.Specifications;

namespace Ritter.Samples.Domain.Rules
{
    public static class EmployeeRules
    {
        public static ValidationRule<Employee> RequiredFields()
        {
            return new ValidationRule<Employee>(new DirectSpecification<Employee>(p => !string.IsNullOrEmpty(p.Name)) & new TrueSpecification<Employee>(), "The Employee name is required", nameof(Employee.Name));
        }

        public static ValidationRule<Employee> Transient()
        {
            return new ValidationRule<Employee>(new DirectSpecification<Employee>(p => p.IsTransient()), "The Employee is transient", nameof(Employee.Name));
        }
    }
}
