using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_IsNot
    {
        [Fact]
        public void EnsureGivenFalseCondition()
        {
            Action act = () => Ensure.Argument.IsNot(false);
            act.ShouldNotThrow<ArgumentException>();
        }

        [Fact]
        public void EnsureGivenFalseConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.IsNot(false, "Test");
            act.ShouldNotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenTrueCondition()
        {
            Action act = () => Ensure.Argument.IsNot(true);
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenTrueConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.IsNot(true, "Test");
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("Test");
        }
    }
}
