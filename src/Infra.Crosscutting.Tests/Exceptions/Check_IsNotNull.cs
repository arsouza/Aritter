using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
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
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Check.IsNotNull(null, "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);
        }
    }
}
