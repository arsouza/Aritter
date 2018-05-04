using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_NotNull
    {
        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () => Ensure.NotNull(null);
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNull(null, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenNotNull()
        {
            Action act = () => Ensure.NotNull(new object());
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenNotNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNull(new object(), "Test");
            act.Should().NotThrow<Exception>();
        }
    }
}
