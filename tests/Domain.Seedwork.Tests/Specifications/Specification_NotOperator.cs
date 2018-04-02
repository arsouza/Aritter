using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class Specification_NotOperator
    {
        [Fact]
        public void ReturnAnNotSpecificationGivenAnotherSpecification()
        {
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var notSpec = !spec2;

            notSpec.Should().BeOfType<NotSpecification<EntityTest>>();
            notSpec.IsSatisfiedBy(new EntityTest()).Should().BeFalse();
        }
    }
}
