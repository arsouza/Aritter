using System;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_NotNullOrEmpty
    {
        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () => Ensure.NotNullOrEmpty(null);
            act.Should().Throw<Exception>().And.Message.Should().Be(Messages.StringCannotBeNullOrEmpty);
        }

        [Fact]
        public void ThrowExceptionGivenNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty(null, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void ThrowExceptionGivenEmpty()
        {
            Action act = () => Ensure.NotNullOrEmpty("");
            act.Should().Throw<Exception>().And.Message.Should().Be(Messages.StringCannotBeNullOrEmpty);
        }

        [Fact]
        public void ThrowExceptionGivenEmptyAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty("", "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenNotNull()
        {
            Action act = () => Ensure.NotNullOrEmpty("test");
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenNotNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty("test", "Test");
            act.Should().NotThrow<Exception>();
        }
    }
}
