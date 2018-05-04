using FluentAssertions;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Items
    {
        [Fact]
        public void ThrowExceptionGivenNullCollection()
        {
            int[] collection = null;
            Action act = () => Ensure.Items<int>(collection, p => p == 0);
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionNotMatchPredicate()
        {
            int[] collection = new[] { 0 };
            Action act = () => Ensure.Items<int>(collection, p => p > 0);
            act.Should().Throw<Exception>().And.Message.Should().Be("");
        }

        [Fact]
        public void ThrowExceptionGivenNullCollectionAndMessage()
        {
            int[] collection = null;
            Action act = () => Ensure.Items<int>(collection, p => p == 0, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }

        [Fact]
        public void ThrowExceptionNotMatchPredicateGivenMessage()
        {
            int[] collection = new[] { 0 };
            Action act = () => Ensure.Items<int>(collection, p => p > 0, "Test");
            act.Should().Throw<Exception>().And.Message.Should().Be("Test");
        }
        
        [Fact]
        public void EnsureMatchPredicate()
        {
            int[] collection = new[] { 0 };
            Action act = () => Ensure.Items<int>(collection, p => p == 0);
            act.Should().NotThrow<Exception>();
        }
    }
}
