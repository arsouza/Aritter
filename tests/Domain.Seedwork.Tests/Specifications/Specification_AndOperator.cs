using FluentAssertions;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Specifications
{
    public class Specification_AndOperator
    {
        [Fact]
        public void ReturnAnAndSpecificationGivenAnotherSpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            Specification<EntityTest> andSpec = spec1 && spec2;

            andSpec.Should().BeOfType<AndSpecification<EntityTest>>();
            andSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }

        [Fact]
        public void ReturnLeftAndRightSpecificationGivenAnotherSpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var andSpec = (spec1 && spec2) as AndSpecification<EntityTest>;

            andSpec.Should().NotBeNull();
            andSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
            andSpec.LeftSideSpecification.Should().Be(spec1);
            andSpec.RightSideSpecification.Should().Be(spec2);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullRightSpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = null;

            Action act = () =>
            {
                var andSpec = (spec1 && spec2) as AndSpecification<EntityTest>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: rightSideSpecification");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullLeftSpecification()
        {
            Specification<EntityTest> spec1 = null;
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            Action act = () =>
            {
                var andSpec = (spec1 && spec2) as AndSpecification<EntityTest>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: leftSideSpecification");
        }
    }
}
