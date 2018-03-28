using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_Is
    {
        [Fact]
        public void EnsureGivenTrueCondition()
        {
            Action act = () => Ensure.Argument.Is(true);
            act.ShouldNotThrow<ArgumentException>();
        }

        [Fact]
        public void EnsureGivenTrueConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.Is(true, "Test");
            act.ShouldNotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenFalseCondition()
        {
            Action act = () => Ensure.Argument.Is(false);
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenFalseConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.Is(false, "Test");
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("Test");
        }
    }
}
