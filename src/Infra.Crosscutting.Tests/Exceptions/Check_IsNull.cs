using FluentAssertions;
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
            Action act = () => Check.IsNull(null, "Message");
            act.ShouldNotThrow();
        }

        [Fact]
        public void ThrowExceptionGivenNotNull()
        {
             Action act = () => Check.IsNull("test", "message");
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("message");
        }
    }
}
