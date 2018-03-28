using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Not
    {
        [Fact]
        public void ThrowExceptionGivenTrue()
        {
            Action act = () => Ensure.Not(true);
            act.ShouldThrow<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenTrueAndNotEmptyMessage()
        {
            Action act = () => Ensure.Not(true, "Test");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void NotThrowExceptionGivenFalse()
        {
            Action act = () => Ensure.Not(false);
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void NotThrowExceptionGivenFalseAndNotEmptyMessage()
        {
            Action act = () => Ensure.Not(false, "Test");
            act.ShouldNotThrow<Exception>();
        }
    }
}
