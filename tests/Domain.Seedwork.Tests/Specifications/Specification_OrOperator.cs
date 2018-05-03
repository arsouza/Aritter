using FluentAssertions;
using Ritter.Domain.Specifications;
using Ritter.Domain.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Domain.Tests.Specifications
{
    public class Specification_OrOperator
    {
        [Fact]
        public void GivenTransientEntityThenSatisfySpecification()
        {
            var spec1 = new TrueSpecification<EntityTest>();
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 1);

            var orSpec = spec1 || spec2;

            orSpec.Should().BeOfType<OrSpecification<EntityTest>>();
            orSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
        }

        [Fact]
        public void GivenNotTransientEntityThenSatisfySpecification()
        {
            var spec1 = new TrueSpecification<EntityTest>();
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 1);

            var orSpec = spec1 || spec2;

            orSpec.Should().BeOfType<OrSpecification<EntityTest>>();
            orSpec.IsSatisfiedBy(new EntityTest(1)).Should().BeTrue();
        }

        [Fact]
        public void GivenTwoSpecificationsThenReturnLeftAndRightSpecification()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var orSpec = (spec1 || spec2) as OrSpecification<EntityTest>;

            orSpec.Should().NotBeNull();
            orSpec.IsSatisfiedBy(new EntityTest()).Should().BeTrue();
            orSpec.LeftSideSpecification.Should().Be(spec1);
            orSpec.RightSideSpecification.Should().Be(spec2);
        }

        [Fact]
        public void GivenNullRightSpecificationThenThrowArgumentNullException()
        {
            Specification<EntityTest> spec1 = new TrueSpecification<EntityTest>();
            Specification<EntityTest> spec2 = null;

            Action act = () =>
            {
                var orSpec = (spec1 || spec2) as AndSpecification<EntityTest>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: rightSideSpecification");
        }

        [Fact]
        public void GivenNullLeftSpecificationThenThrowArgumentNullException()
        {
            Specification<EntityTest> spec1 = null;
            Specification<EntityTest> spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            Action act = () =>
            {
                var orSpec = (spec1 || spec2) as AndSpecification<EntityTest>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: leftSideSpecification");
        }
    }
}
