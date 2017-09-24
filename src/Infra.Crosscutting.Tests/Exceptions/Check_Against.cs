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
            Check.Against<Exception>(() => { return false; }, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenTrueFunction()
        {
            Exception exception = Assert.Throws<Exception>(() =>
            {
                Check.Against<Exception>(() => { return true; }, "Message");
            });

            Assert.NotNull(exception);
            Assert.Equal("Message", exception.Message);
        }
    }
}
