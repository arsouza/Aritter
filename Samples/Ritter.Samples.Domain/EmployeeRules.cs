using Ritter.Domain.Seedwork.Rules.Business;
using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Domain.Seedwork.Specs;
using System;

namespace Ritter.Samples.Domain
{
    public static class EmployeeRules
    {
        public static ValidationRule<Employee> RequiredFieldsValidation()
        {
            return new ValidationRule<Employee>(SharedSpecs.Direct<Employee>(p => !string.IsNullOrEmpty(p.Name)) & SharedSpecs.True<Employee>(), "The Employee name is required", nameof(Employee.Name));
        }

        public static ValidationRule<Employee> TransientValidation()
        {
            return new ValidationRule<Employee>(new DirectSpecification<Employee>(p => p.IsTransient()), "The Employee is transient", nameof(Employee.Name));
        }

        public static BusinessRule<Employee> MakeEmployeeTransient(Action<Employee> action)
        {
            return new BusinessRule<Employee>(new DirectSpecification<Employee>(p => !p.IsTransient()), action);
        }
    }
}
