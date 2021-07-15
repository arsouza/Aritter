using System;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_NotNullOrWhiteSpace
    {
        [Fact]
        public void EnsureGivenNotNullString()
        {
            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace("test");
            act.Should().NotThrow<ArgumentException>();
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void EnsureGivenNotNullStringAndAParamName()
        {
            TestObject1 obj = new TestObject1() { Value = "test" };

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value));
            act.Should().NotThrow<ArgumentException>();
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void EnsureGivenNotNullStringAndAParamNameAndAMessage()
        {
            TestObject1 obj = new TestObject1() { Value = "test" };

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value), "Test");
            act.Should().NotThrow<ArgumentException>();
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullString()
        {
            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(null);
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().BeNull();
            act.Should().Throw<ArgumentNullException>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullStringAndAParamName()
        {
            TestObject1 obj = new TestObject1();

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.Should().Throw<ArgumentNullException>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullStringAndAParamNameAndAMessage()
        {
            TestObject1 obj = new TestObject1();

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value), "Test");
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.Should().Throw<ArgumentNullException>().And.Message.Should().Contain("Test");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyString()
        {
            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace("");
            act.Should().Throw<ArgumentException>().And.ParamName.Should().BeNullOrEmpty();
            act.Should().Throw<ArgumentException>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyStringAndAParamName()
        {
            TestObject1 obj = new TestObject1() { Value = "" };

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value));
            act.Should().Throw<ArgumentException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.Should().Throw<ArgumentException>().And.Message.Should().Contain(Messages.StringCannotBeNullOrWhitespace);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyStringAndAParamNameAndAMessage()
        {
            TestObject1 obj = new TestObject1() { Value = "" };

            Action act = () => Ensure.ArgumentNotNullOrWhiteSpace(obj.Value, nameof(TestObject1.Value), "Test");
            act.Should().Throw<ArgumentException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.Should().Throw<ArgumentException>().And.Message.Should().Contain("Test");
        }
    }
}
