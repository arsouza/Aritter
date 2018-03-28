using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_That
    {
        [Fact]
        public void ThrowExceptionGivenFalse()
        {
            Action act = () => Ensure.That(false);
            act.ShouldThrow<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenFalseAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(false, "Test");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenTrue()
        {
            Action act = () => Ensure.That(true);
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenTrueAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(true, "Test");
            act.ShouldNotThrow<Exception>();
        }
    }
}
