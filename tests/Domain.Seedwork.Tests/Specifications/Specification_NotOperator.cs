using FluentAssertions;
using Ritter.Domain.Specifications;
using Ritter.Domain.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Domain.Tests.Specifications
{
    public class Specification_NotOperator
    {
        [Fact]
        public void GivenTransientEntityThenNotSatisfySpecification()
        {
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var notSpec = !spec2;

            notSpec.Should().BeOfType<NotSpecification<EntityTest>>();
            notSpec.IsSatisfiedBy(new EntityTest()).Should().BeFalse();
        }

        [Fact]
        public void GivenNotTransientEntityThenSatisfySpecification()
        {
            var spec2 = new DirectSpecification<EntityTest>(e => e.Id == 0);

            var notSpec = !spec2;

            notSpec.Should().BeOfType<NotSpecification<EntityTest>>();
            notSpec.IsSatisfiedBy(new EntityTest(1)).Should().BeTrue();
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullSpecification()
        {
            Specification<EntityTest> spec2 = null;

            Action act = () =>
            {
                var notSpec = !spec2;
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: originalSpecification");
        }
    }
}
