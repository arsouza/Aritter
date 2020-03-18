using System;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_NotNullOrWhiteSpace
    {
        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace(null);
            act.Should().Throw<Exception>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowExceptionGivenNullAndNotWhiteSpaceMessage()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace(null, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void ThrowExceptionGivenEmpty()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace("");
            act.Should().Throw<Exception>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowExceptionGivenWhiteSpace()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace(" ");
            act.Should().Throw<Exception>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowExceptionGivenWhiteSpaceAndNotWhiteSpaceMessage()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace("", "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenNotNull()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace("test");
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenNotNullAndNotWhiteSpaceMessage()
        {
            Action act = () => Ensure.NotNullOrWhiteSpace("test", "Test");
            act.Should().NotThrow<Exception>();
        }
    }
}
