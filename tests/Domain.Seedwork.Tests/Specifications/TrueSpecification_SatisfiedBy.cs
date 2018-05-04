using FluentAssertions;
using Ritter.Domain.Specifications;
using Ritter.Domain.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Tests.Specifications
{
    public class TrueSpecification_SatisfiedBy
    {
        [Fact]
        public void GivenTransientEntityThenSatisfySpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            spec1.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }
    }
}
