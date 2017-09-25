using Ritter.Infra.Crosscutting.Exceptions;
using Xunit;
using System;
using FluentAssertions;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{

    public class Check_IsTypeOf
    {
        [Fact]
        public void NotThrowExceptionGivenValidString()
        {
            Action act = () => Check.IsTypeOf<string>("test", "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void NotThrowExceptionGivenValidInt()
        {
            Action act = () => Check.IsTypeOf<int>(1, "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void NotThrowExceptionGivenValidDateTime()
        {
            Action act = () => Check.IsTypeOf<DateTime>(DateTime.Now, "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void ThrowExceptionGivenInvalidString()
        {
            Action act = () => Check.IsTypeOf<string>(1, "Message");
            act.ShouldThrow<InvalidOperationException>().And.Message.Should().Be("Message");
        }

        [Fact]
        public void ThrowExceptionGivenInvalidInt()
        {
            Action act = () => Check.IsTypeOf<int>("test", "Message");
            act.ShouldThrow<InvalidOperationException>().And.Message.Should().Be("Message");
        }

        [Fact]
        public void ThrowExceptionGivenInvalidDateTime()
        {
            Action act = () => Check.IsTypeOf<DateTime>(1, "Message");
            act.ShouldThrow<InvalidOperationException>().And.Message.Should().Be("Message");
        }
    }
}
