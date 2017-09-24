using Ritter.Infra.Crosscutting.Exceptions;
using System;
using Xunit;
using FluentAssertions;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{
    public class Check_AreEquals
    {
        [Fact]
        public void NotThrowExceptionGivenEqualValues()
        {
            Action act = () =>
            {
                Check.AreEquals<Exception>("test", "test", "Message");
                Check.AreEquals<Exception>(1, 1, "Message");
            };

            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void ThrowExceptionGivenNotEqualValues()
        {
            Action act = () => Check.AreEquals<Exception>("test", "no-test", "Message");
            act.ShouldThrow<Exception>().And.Message.Should().Be("Message");
        }
    }
}
