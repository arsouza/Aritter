using Ritter.Domain.Seedwork.Rules.Business;

namespace Ritter.Samples.Domain
{
    public sealed class EmployeeRulesEvaluator : BusinessRulesEvaluator<Employee>
    {
        public EmployeeRulesEvaluator()
        {
            AddRule("MakeEmployeeTransient", EmployeeRules.MakeEmployeeTransient(p =>
            {
                p.SetId(0);
            }));
        }
    }
}
