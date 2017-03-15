using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
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
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Check.IsNull("test", "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", (exception as ArgumentNullException).ParamName);
        }
    }
}
