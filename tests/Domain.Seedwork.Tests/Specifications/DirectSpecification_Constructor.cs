using FluentAssertions;
using Ritter.Domain.Specifications;
using Ritter.Domain.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Domain.Tests.Specifications
{
    public class DirectSpecification_Constructor
    {
        [Fact]
        public void GivenValidCriteriaThenReturnNewInstance()
        {
            Specification<EntityTest> spec1 = null;

            Action act = () =>
            {
                spec1 = new DirectSpecification<EntityTest>(e => e.Id == 0);
            };

            act.Should().NotThrow();
            spec1.Should().NotBeNull();
            spec1.Should().BeOfType<DirectSpecification<EntityTest>>();
        }

        [Fact]
        public void GivenNullCriteriaThenThrowException()
        {
            Specification<EntityTest> spec1 = null;

            Action act = () =>
            {
                spec1 = new DirectSpecification<EntityTest>(null);
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: matchingCriteria");
        }
    }
}
