using Ritter.Infra.Crosscutting.Exceptions;
using Xunit;
using System;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{

    public class Check_IsTypeOf
    {
        [Fact]
        public void NotThrowExceptionGivenCorrectInstanceType()
        {
            Check.IsTypeOf<string>("test", "Message");
            Check.IsTypeOf<int>(1, "Message");
            Check.IsTypeOf<DateTime>(DateTime.Now, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenIncorrectInstanceType()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Check.IsTypeOf<string>(1, "Message");
            });

            Assert.NotNull(exception);
            Assert.Equal("Message", exception.Message);
        }
    }
}
