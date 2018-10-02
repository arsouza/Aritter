using FluentAssertions;
using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Specifications
{
    public class DirectSpecification_Constructor
    {
        [Fact]
        public void GivenValidCriteriaThenReturnNewInstance()
        {
            Specification<TestObject1> spec1 = null;

            Action act = () =>
            {
                spec1 = new DirectSpecification<TestObject1>(e => e.Id == 0);
            };

            act.Should().NotThrow();
            spec1.Should().NotBeNull();
            spec1.Should().BeOfType<DirectSpecification<TestObject1>>();
        }

        [Fact]
        public void GivenNullCriteriaThenThrowException()
        {
            Specification<TestObject1> spec1 = null;

            Action act = () =>
            {
                spec1 = new DirectSpecification<TestObject1>(null);
            };

            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Object value cannot be null\r\nParameter name: matchingCriteria");
        }
    }
}
