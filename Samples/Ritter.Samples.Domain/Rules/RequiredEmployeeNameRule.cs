using Ritter.Domain.Seedwork.Rules.Validation;
using Ritter.Domain.Seedwork.Specifications;

namespace Ritter.Samples.Domain.Rules
{
    public class RequiredEmployeeNameRule : ValidationRule<Employee>
    {
        private static ISpecification<Employee> requiredNameSpecification = new DirectSpecification<Employee>(p => !string.IsNullOrEmpty(p.Name));

        public RequiredEmployeeNameRule()
            : base(requiredNameSpecification, "The Employee name is required", nameof(Employee.Name))
        {
        }
    }
}
