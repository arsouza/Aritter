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
            act.ShouldThrow<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNull(null, "Test");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void NotThrowExceptionGivenNotNull()
        {
            Action act = () => Ensure.NotNull(new object());
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void NotThrowExceptionGivenNotNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNull(new object(), "Test");
            act.ShouldNotThrow<Exception>();
        }
    }
}
