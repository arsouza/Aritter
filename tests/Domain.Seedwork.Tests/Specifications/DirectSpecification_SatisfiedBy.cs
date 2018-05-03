using FluentAssertions;
using Ritter.Domain.Specifications;
using Ritter.Domain.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Tests.Specifications
{
    public class DirectSpecification_SatisfiedBy
    {
        [Fact]
        public void GivenTransientEntityThenSatisfySpecification()
        {
            Specification<EntityTest> spec1 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            spec1.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }

        [Fact]
        public void GivenNotTransientEntityThenNotSatisfySpecification()
        {
            Specification<EntityTest> spec1 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            spec1.IsSatisfiedBy(new EntityTest(1)).Should().BeFalse();
        }
    }
}
