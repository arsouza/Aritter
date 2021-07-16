using System;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_That
    {
        [Fact]
        public void ThrowExceptionGivenFalse()
        {
            Action act = () => Ensure.That(false);
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenFalseAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(false, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenTrue()
        {
            Action act = () => Ensure.That(true);
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenTrueAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(true, "Test");
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void ThrowExceptionGivenFalsePredicate()
        {
            Action act = () => Ensure.That(() => false);
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenFalsePredicateAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(() => false, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void EnsureGivenTruePredicate()
        {
            Action act = () => Ensure.That(() => true);
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void EnsureGivenTruePredicateAndNotEmptyMessage()
        {
            Action act = () => Ensure.That(() => true, "Test");
            act.Should().NotThrow<Exception>();
        }
    }
}
