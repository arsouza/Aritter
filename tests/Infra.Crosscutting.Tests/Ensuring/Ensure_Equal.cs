using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Equal
    {
        [Fact]
        public void ThrowsExceptionGivenNotEqualsPrimitives()
        {
            var a = 1;
            var b = 2;

            Action act = () => Ensure.Equal(a, b);
            act.Should().Throw<Exception>().And.Message.Should().Be("Values must be equal");
        }

        [Fact]
        public void ThrowsExceptionGivenNotEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = new TestObject1();

            Action act = () => Ensure.Equal(a, b);
            act.Should().Throw<Exception>().And.Message.Should().Be("Values must be equal");
        }

        [Fact]
        public void EnsureGivenEqualsPrimitives()
        {
            var a = 1;
            var b = 1;

            Action act = () => Ensure.Equal(a, b);
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = a;

            Action act = () => Ensure.Equal(a, b);
            act.Should().NotThrow<Exception>();
        }
    }
}
