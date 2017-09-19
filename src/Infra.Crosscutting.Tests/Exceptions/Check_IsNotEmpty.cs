using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{
    public class Check_IsNotEmpty
    {
        [Fact]
        public void NotThrowExceptionGivenNotEmpty()
        {
            Check.IsNotEmpty("Test", "Message");
            Check.IsNotEmpty(new int[] { 1 }, "Message");
        }

        [Fact]
        public void ThrowExceptionGivenEmpty()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                Check.IsNotEmpty("", "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);

            exception = Assert.Throws<ArgumentException>(() =>
            {
                Check.IsNotEmpty(new int[] { }, "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Check.IsNotEmpty(null, "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);

            exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Check.IsNotEmpty<int>(null, "value");
            });

            Assert.NotNull(exception);
            Assert.Equal("value", exception.ParamName);
        }
    }
}
