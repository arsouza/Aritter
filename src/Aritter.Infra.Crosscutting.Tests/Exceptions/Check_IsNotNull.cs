using Aritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
{
    public class Check_IsNotNull
    {
        [Fact]
        public void NotThrowExceptionGivenNotNull()
        {
            Check.IsNotNull("test", "Message");
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                Check.IsNotNull(null, "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);
        }
    }
}
