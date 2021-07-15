using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_Is
    {
        [Fact]
        public void EnsureGivenTrueCondition()
        {
            Action act = () => Ensure.ArgumentIs(true);
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void EnsureGivenTrueConditionAndAMessage()
        {
            Action act = () => Ensure.ArgumentIs(true, "Test");
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenFalseCondition()
        {
            Action act = () => Ensure.ArgumentIs(false);
            act.Should().Throw<ArgumentException>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenFalseConditionAndAMessage()
        {
            Action act = () => Ensure.ArgumentIs(false, "Test");
            act.Should().Throw<ArgumentException>().And.Message.Should().Be("Test");
        }
    }
}
