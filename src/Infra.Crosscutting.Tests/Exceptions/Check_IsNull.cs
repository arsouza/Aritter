using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{
    public class Check_IsNull
    {
        [Fact]
        public void NotThrowExceptionGivenNull()
        {
            Check.IsNull(null, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenNotNull()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                Check.IsNull("test", "message");
            });

            Assert.NotNull(exception);
            Assert.Equal("message", exception.Message);
        }
    }
}
