using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{

    public class Check_Against
    {
        [Fact]
        public void NotThrowAnyExceptionGivenFalse()
        {
            Check.Against<Exception>(false, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenTrue()
        {
            Exception exception = Assert.Throws<Exception>(() =>
            {
                Check.Against<Exception>(true, "Message");
            });

            Assert.NotNull(exception);
            Assert.Equal("Message", exception.Message);
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
