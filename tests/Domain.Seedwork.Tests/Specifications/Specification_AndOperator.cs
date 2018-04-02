using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class Specification_AndOperator
    {
        [Fact]
        public void ReturnAnAndSpecificationGivenAnotherSpecification()
        {
            var spec1 = new TrueSpecification<EntityTest>();
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var andSpec = spec1 && spec2;

            andSpec.Should().BeOfType<AndSpecification<EntityTest>>();
            andSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }
    }
}
