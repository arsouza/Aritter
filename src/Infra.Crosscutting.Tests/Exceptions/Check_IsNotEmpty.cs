using FluentAssertions;
using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{
    public class Check_IsNotEmpty
    {
        [Fact]
        public void NotThrowExceptionGivenStringNotEmpty()
        {
            Action act = () => Check.IsNotEmpty("Test", "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void NotThrowExceptionGivenEnumerableNotEmpty()
        {
            Action act = () => Check.IsNotEmpty(new int[] { 1 }, "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void ThrowExceptionGivenStringEmpty()
        {
            Action act = () => Check.IsNotEmpty("", "value");
            act.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("value");
        }

        [Fact]
        public void ThrowExceptionGivenEnumerableEmpty()
        {
            Action act = () => Check.IsNotEmpty(new int[] { }, "value");
            act.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("value");
        }

        [Fact]
        public void ThrowExceptionGivenStringNull()
        {
            Action act = () => Check.IsNotEmpty(null, "value");
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("value");
        }

        [Fact]
        public void ThrowExceptionGivenEnumerableNull()
        {
            Action act = () => Check.IsNotEmpty<int>(null, "value");
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("value");
        }
    }
}
