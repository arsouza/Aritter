using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;
using FluentAssertions;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{

    public class Check_Against
    {
        [Fact]
        public void NotThrowAnyExceptionGivenFalse()
        {
            Action act = () => Check.Against<Exception>(false, "Message");
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void ThrowExceptionGivenTrue()
        {
            Action act = () => Check.Against<Exception>(true, "Message");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Message");
        }

        [Fact]
        public void NotThrowAnyExceptionGivenFalseFunction()
        {
            Action act = () => Check.Against<Exception>(() => { return false; }, "Message");
            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void ThrowExceptionGivenTrueFunction()
        {
            Action act = () => Check.Against<Exception>(() => { return true; }, "Message");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Message");
        }
    }
}
