using Aritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
{
    public  class Check_AreEquals
    {
        [Fact]
        public void NotThrowExceptionGivenEqualValues()
        {
            Check.AreEquals<Exception>("test", "test", "Message");
            Check.AreEquals<Exception>(1, 1, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenNotEqualValues()
        {
            Exception exception = Assert.Throws<Exception>(() =>
            {
                Check.AreEquals<Exception>("test", "no-test", "Message");
            });

            Assert.NotNull(exception);
            Assert.Equal("Message", exception.Message);
        }
    }
}
