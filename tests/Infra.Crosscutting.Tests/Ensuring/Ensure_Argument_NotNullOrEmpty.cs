using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Infra.Crosscutting.Tests.Ensuring
{
    public class Ensure_Argument_NotNullOrEmpty
    {
        [Fact]
        public void EnsureGivenNotNullString()
        {
            Action act = () => Ensure.Argument.NotNullOrEmpty("test");
            act.ShouldNotThrow<ArgumentException>();
            act.ShouldNotThrow<ArgumentNullException>();
        }

        [Fact]
        public void EnsureGivenNotNullStringAndAParamName()
        {
            var obj = new TestObject1() { Value = "test" };

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value));
            act.ShouldNotThrow<ArgumentException>();
            act.ShouldNotThrow<ArgumentNullException>();
        }

        [Fact]
        public void EnsureGivenNotNullStringAndAParamNameAndAMessage()
        {
            var obj = new TestObject1() { Value = "test" };

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value), "Test");
            act.ShouldNotThrow<ArgumentException>();
            act.ShouldNotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullString()
        {
            Action act = () => Ensure.Argument.NotNullOrEmpty(null);
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().BeNull();
            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Be("String value cannot be null");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullStringAndAParamName()
        {
            var obj = new TestObject1();

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Be("String value cannot be null\r\nParameter name: Value");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullStringAndAParamNameAndAMessage()
        {
            var obj = new TestObject1();

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value), "Test");
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Be("Test\r\nParameter name: Value");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyString()
        {
            Action act = () => Ensure.Argument.NotNullOrEmpty("");
            act.ShouldThrow<ArgumentException>().And.ParamName.Should().BeNull();
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("String value cannot be empty");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyStringAndAParamName()
        {
            var obj = new TestObject1() { Value = "" };

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("String value cannot be empty\r\nParameter name: Value");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenEmptyStringAndAParamNameAndAMessage()
        {
            var obj = new TestObject1() { Value = "" };

            Action act = () => Ensure.Argument.NotNullOrEmpty(obj.Value, nameof(TestObject1.Value), "Test");
            act.ShouldThrow<ArgumentException>().And.ParamName.Should().Be(nameof(TestObject1.Value));
            act.ShouldThrow<ArgumentException>().And.Message.Should().Be("Test\r\nParameter name: Value");
        }
    }
}
