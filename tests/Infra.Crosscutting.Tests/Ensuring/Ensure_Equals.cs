using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Equals
    {
        [Fact]
        public void ThrowsExceptionGivenNotEqualsPrimitives()
        {
            var a = 1;
            var b = 2;

            Action act = () => Ensure.Equal(a, b);
            act.ShouldThrow<Exception>().And.Message.Should().Be("Values must be equal");
        }

        [Fact]
        public void ThrowsExceptionGivenNotEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = new TestObject1();

            Action act = () => Ensure.Equal(a, b);
            act.ShouldThrow<Exception>().And.Message.Should().Be("Values must be equal");
        }

        [Fact]
        public void NotThrowsExceptionGivenEqualsPrimitives()
        {
            var a = 1;
            var b = 1;

            Action act = () => Ensure.Equal(a, b);
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void NotThrowsExceptionGivenEqualsNonPrimitives()
        {
            var a = new TestObject1();
            var b = a;

            Action act = () => Ensure.Equal(a, b);
            act.ShouldNotThrow<Exception>();
        }
    }
}
