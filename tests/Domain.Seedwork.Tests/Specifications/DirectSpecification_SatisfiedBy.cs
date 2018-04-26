using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
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
