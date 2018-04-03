using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class ParameterRebinder_VisitParameter
    {
        [Fact]
        public void ReturnNewInstanceGivenNullMap()
        {
            Dictionary<ParameterExpression, ParameterExpression> map = null;

            ParameterRebinder parameterRebinder = new ParameterRebinder(map);
            parameterRebinder.Should().NotBeNull();

            Expression exp = parameterRebinder.Visit((Expression)null);
            exp.Should().BeNull();
        }

        [Fact]
        public void ReturnNewInstanceGivenMap()
        {
            Dictionary<ParameterExpression, ParameterExpression> map = new Dictionary<ParameterExpression, ParameterExpression>();

            ParameterRebinder parameterRebinder = new ParameterRebinder(map);
            parameterRebinder.Should().NotBeNull();

            Expression exp = parameterRebinder.Visit((Expression)null);
            exp.Should().BeNull();
        }
    }
}
