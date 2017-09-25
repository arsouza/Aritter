using FluentAssertions;
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
            Action act = () => Check.IsNotNull("test", "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () => Check.IsNotNull(null, "value");
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("value");
        }
    }
}
