using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specs
{
    public sealed class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            if (map.TryGetValue(parameterExpression, out ParameterExpression replacement))
                parameterExpression = replacement;

            return base.VisitParameter(parameterExpression);
        }
    }
}
