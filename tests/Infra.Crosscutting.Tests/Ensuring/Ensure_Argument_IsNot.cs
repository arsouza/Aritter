using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_IsNot
    {
        [Fact]
        public void EnsureGivenFalseCondition()
        {
            Action act = () => Ensure.Argument.IsNot(false);
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void EnsureGivenFalseConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.IsNot(false, "Test");
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenTrueCondition()
        {
            Action act = () => Ensure.Argument.IsNot(true);
            act.Should().Throw<ArgumentException>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenTrueConditionAndAMessage()
        {
            Action act = () => Ensure.Argument.IsNot(true, "Test");
            act.Should().Throw<ArgumentException>().And.Message.Should().Be("Test");
        }
    }
}
