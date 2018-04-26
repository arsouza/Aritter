using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
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
