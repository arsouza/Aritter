using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            ReadOnlyCollection<Expression> exps = parameterRebinder.Visit(new ReadOnlyCollection<Expression>(new List<Expression> { null }));
            exps.Should().NotBeNullOrEmpty();
            exps.First().Should().BeNull();
        }
    }
}
