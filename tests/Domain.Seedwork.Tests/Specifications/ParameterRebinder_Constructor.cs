using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class ParameterRebinder_Constructor
    {
        [Fact]
        public void ReturnNewInstanceGivenNullMap()
        {
            Dictionary<ParameterExpression, ParameterExpression> map = null;

            ParameterRebinder parameterRebinder = new ParameterRebinder(map);

            parameterRebinder.Should().NotBeNull();
        }
    }
}
