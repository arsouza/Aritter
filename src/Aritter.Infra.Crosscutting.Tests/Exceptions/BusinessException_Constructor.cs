using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
{
    public class BusinessException_Constructor
    {
        [Fact]
        public void ThrowsBusinessExceptionWithDefaultMessageSuccessfully()
        {
            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                throw new BusinessException();
            }));

            Assert.Equal("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.NotNull(exception.Errors);
            Assert.Equal(0, exception.Errors.Count);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithCustomMessageSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";

            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                throw new BusinessException(message);
            }));

            Assert.Equal(message, exception.Message);
            Assert.NotNull(exception.Errors);
            Assert.Equal(0, exception.Errors.Count);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithCustomMessageAndErrorsSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";

            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                throw new BusinessException(message, "Error1", "Error2");
            }));

            Assert.Equal(message, exception.Message);
            Assert.NotNull(exception.Errors);
            Assert.Equal(2, exception.Errors.Count);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithDefaultMessageAndErrorsSuccessfully()
        {
            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                throw new BusinessException(new string[] { "Error1", "Error2" });
            }));

            Assert.Equal("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.NotNull(exception.Errors);
            Assert.Equal(2, exception.Errors.Count);
            Assert.Equal("Error1", exception.Errors.ElementAt(0));
            Assert.Equal("Error2", exception.Errors.ElementAt(1));
        }

        [Fact]
        public void ThrowsBusinessExceptionWithException()
        {
            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex);
                }
            }));

            Assert.Equal("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(Exception), exception.InnerException.GetType());
            Assert.NotNull(exception.Errors);
            Assert.Equal(0, exception.Errors.Count);
        }

        [Fact]
        public void ThrowsBusinessExceptionWithExceptionAndErrors()
        {
            BusinessException exception = Assert.Throws<BusinessException>(new Action(() =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex, "Error1", "Error2");
                }
            }));

            Assert.Equal("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(Exception), exception.InnerException.GetType());
            Assert.NotNull(exception.Errors);
            Assert.Equal(2, exception.Errors.Count);
            Assert.Equal("Error1", exception.Errors.ElementAt(0));
            Assert.Equal("Error2", exception.Errors.ElementAt(1));
        }
    }
}
