using FluentAssertions;
using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Specifications
{
    public class Specification_AndOperator
    {
        [Fact]
        public void GivenTransientEntityThenSatisfySpecification()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = new DirectSpecification<TestObject1>(e => e.Id == 0);

            Specification<TestObject1> andSpec = spec1 && spec2;

            andSpec.Should().BeOfType<AndSpecification<TestObject1>>();
            andSpec.IsSatisfiedBy(new TestObject1()).Should().BeTrue();
        }

        [Fact]
        public void GivenNotTransientEntityThenNotSatisfySpecification()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = new DirectSpecification<TestObject1>(e => e.Id == 0);

            Specification<TestObject1> andSpec = spec1 && spec2;

            andSpec.Should().BeOfType<AndSpecification<TestObject1>>();
            andSpec.IsSatisfiedBy(new TestObject1(1)).Should().BeFalse();
        }

        [Fact]
        public void GivenTwoSpecificationsThenReturnLeftAndRightSpecification()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = new DirectSpecification<TestObject1>(e => e.Id == 0);

            var andSpec = (spec1 && spec2) as AndSpecification<TestObject1>;

            andSpec.Should().NotBeNull();
            andSpec.IsSatisfiedBy(new TestObject1()).Should().BeTrue();
            andSpec.LeftSideSpecification.Should().Be(spec1);
            andSpec.RightSideSpecification.Should().Be(spec2);
        }

        [Fact]
        public void GivenNullRightSpecificationThenThrowArgumentNullException()
        {
            Specification<TestObject1> spec1 = new TrueSpecification<TestObject1>();
            Specification<TestObject1> spec2 = null;

            Action act = () =>
            {
                var andSpec = (spec1 && spec2) as AndSpecification<TestObject1>;
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
                var andSpec = (spec1 && spec2) as AndSpecification<TestObject1>;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null (Parameter 'leftSideSpecification')");
        }
    }
}
