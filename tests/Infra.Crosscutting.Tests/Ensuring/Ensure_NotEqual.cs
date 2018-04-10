using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_NotEqual
    {
        [Fact]
        public void ThrowsExceptionGivenEqualsPrimitives()
        {
            var a = 1;
            var b = 1;

            Action act = () => Ensure.NotEqual(a, b);
            act.Should().Throw<Exception>().And.Message.Should().Be("Values must not be equal");
        }

        [Fact]
        public void ThrowsExceptionGivenEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = a;

            Action act = () => Ensure.NotEqual(a, b);
            act.Should().Throw<Exception>().And.Message.Should().Be("Values must not be equal");
        }

        [Fact]
        public void EnsureGivenNotEqualsPrimitives()
        {
            var a = 1;
            var b = 2;

            Action act = () => Ensure.NotEqual(a, b);
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenNotEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = new TestObject1();

            Action act = () => Ensure.NotEqual(a, b);
            act.Should().NotThrow<Exception>();
        }
    }
}
