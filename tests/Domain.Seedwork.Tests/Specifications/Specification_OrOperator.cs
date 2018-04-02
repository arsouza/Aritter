using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class Specification_OrOperator
    {
        [Fact]
        public void ReturnAnOrSpecificationGivenAnotherSpecification()
        {
            var spec1 = new TrueSpecification<EntityTest>();
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 1);

            var orSpec = spec1 || spec2;

            orSpec.Should().BeOfType<OrSpecification<EntityTest>>();
            orSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }

        [Fact]
        public void ReturnLeftAndRightSpecificationGivenAnotherSpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var orSpec = (spec1 || spec2) as OrSpecification<EntityTest>;

            orSpec.Should().NotBeNull();
            orSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
            orSpec.LeftSideSpecification.Should().Be(spec1);
            orSpec.RightSideSpecification.Should().Be(spec2);
        }
    }
}
