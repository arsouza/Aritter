using FluentAssertions;
using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Specifications
{
    public class Specification_OrOperator
    {
        [Fact]
        public void GivenTransientEntityThenSatisfySpecification()
        {
            var spec1 = new TrueSpecification<TestObject1>();
            var spec2 = new DirectSpecification<TestObject1>(e => e.Id == 1);

            var orSpec = spec1 || spec2;

            orSpec.Should().BeOfType<OrSpecification<TestObject1>>();
            orSpec.IsSatisfiedBy(new TestObject1()).Should().BeTrue();
        }

        [Fact]
        public void GivenNotTransientEntityThenSatisfySpecification()
        {
            var spec1 = new TrueSpecification<TestObject1>();
            var spec2 = new DirectSpecification<TestObject1>(e => e.Id == 1);

            var orSpec = spec1 || spec2;

            orSpec.Should().BeOfType<OrSpecification<TestObject1>>();
            orSpec.IsSatisfiedBy(new TestObject1(1)).Should().BeTrue();
        }

        [Fact]
        public void GivenTwoSpecificationsThenReturnLeftAndRightSpecification()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = new DirectSpecification<TestObject1>(e => e.Id == 0);

            var orSpec = (spec1 || spec2) as OrSpecification<TestObject1>;

            orSpec.Should().NotBeNull();
            orSpec.IsSatisfiedBy(new TestObject1()).Should().BeTrue();
            orSpec.LeftSideSpecification.Should().Be(spec1);
            orSpec.RightSideSpecification.Should().Be(spec2);
        }

        [Fact]
        public void GivenNullRightSpecificationThenThrowArgumentNullException()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = null;

            Action act = () =>
            {
                var orSpec = (spec1 || spec2) as AndSpecification<TestObject1>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null (Parameter 'rightSideSpecification')");
        }

        [Fact]
        public void GivenNullLeftSpecificationThenThrowArgumentNullException()
        {
            Specification<TestObject1> spec1 = null;
            Specification<TestObject1> spec2 = new DirectSpecification<TestObject1>(e => e.Id == 0);

            Action act = () =>
            {
                var orSpec = (spec1 || spec2) as AndSpecification<TestObject1>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null (Parameter 'leftSideSpecification')");
        }
    }
}
