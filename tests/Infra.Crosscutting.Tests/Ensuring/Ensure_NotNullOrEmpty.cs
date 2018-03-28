using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_NotNullOrEmpty
    {
        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () => Ensure.NotNullOrEmpty(null);
            act.ShouldThrow<Exception>().And.Message.Should().Be("String cannot be null or empty");
        }

        [Fact]
        public void ThrowExceptionGivenNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty(null, "Test");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Test");
        }
        
        [Fact]
        public void ThrowExceptionGivenEmpty()
        {
            Action act = () => Ensure.NotNullOrEmpty("");
            act.ShouldThrow<Exception>().And.Message.Should().Be("String cannot be null or empty");
        }

        [Fact]
        public void ThrowExceptionGivenEmptyAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty("", "Test");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void NotThrowExceptionGivenNotNull()
        {
            Action act = () => Ensure.NotNullOrEmpty("test");
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void NotThrowExceptionGivenNotNullAndNotEmptyMessage()
        {
            Action act = () => Ensure.NotNullOrEmpty("test", "Test");
            act.ShouldNotThrow<Exception>();
        }
    }
}
