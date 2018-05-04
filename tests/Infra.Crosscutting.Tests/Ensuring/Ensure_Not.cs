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
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenTrueAndNotEmptyMessage()
        {
            Action act = () => Ensure.Not(true, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenFalse()
        {
            Action act = () => Ensure.Not(false);
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenFalseAndNotEmptyMessage()
        {
            Action act = () => Ensure.Not(false, "Test");
            act.Should().NotThrow<Exception>();
        }
    }
}
