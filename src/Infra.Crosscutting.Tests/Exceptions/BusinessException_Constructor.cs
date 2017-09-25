using Ritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Ritter.Infra.Crosscutting.Tests.Exceptions
{
    public class BusinessException_Constructor
    {
        [Fact]
        public void ThrowsBusinessExceptionWithDefaultMessageSuccessfully()
        {
            Action act = () => throw new BusinessException();
            act.ShouldThrow<BusinessException>().And.Message.Should().Be("One or more errors occurs. Check internal errors.");
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithCustomMessageSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";
            Action act = () => throw new BusinessException(message);
            act.ShouldThrow<BusinessException>().And.Message.Should().Be(message);
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithCustomMessageAndErrorsSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";
            Action act = () => throw new BusinessException(message, "Error1", "Error2");
            act.ShouldThrow<BusinessException>().And.Message.Should().Be(message);
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(2);
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(0).Should().Be("Error1");
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(1).Should().Be("Error2");
        }

        [Fact]
        public void ThrowsBusinessExceptionWithDefaultMessageAndErrorsSuccessfully()
        {
            Action act = () => throw new BusinessException(new string[] { "Error1", "Error2" });
            act.ShouldThrow<BusinessException>().And.Message.Should().Be("One or more errors occurs. Check internal errors.");
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(2);
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(0).Should().Be("Error1");
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(1).Should().Be("Error2");
        }

        [Fact]
        public void ThrowsBusinessExceptionWithException()
        {
            Action act = () =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex);
                }
            };

            act.ShouldThrow<BusinessException>().And.Message.Should().Be("One or more errors occurs. Check internal errors.");
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(0);
            act.ShouldThrow<BusinessException>().And.InnerException.Should().NotBeNull().And.BeOfType<Exception>();
        }

        [Fact]
        public void ThrowsBusinessExceptionWithExceptionAndErrors()
        {
            Action act = () =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex, "Error1", "Error2");
                }
            };

            act.ShouldThrow<BusinessException>().And.Message.Should().Be("One or more errors occurs. Check internal errors.");
            act.ShouldThrow<BusinessException>().And.Errors.Should().NotBeNull().And.HaveCount(2);
            act.ShouldThrow<BusinessException>().And.InnerException.Should().NotBeNull().And.BeOfType<Exception>();
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(0).Should().Be("Error1");
            act.ShouldThrow<BusinessException>().And.Errors.ElementAt(1).Should().Be("Error2");
        }
    }
}
