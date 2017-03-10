using System;
using System.Linq;
using Aritter.Infra.Crosscutting.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
{
    [TestClass]
    public class BusinessExceptionTest
    {
        [TestMethod]
        public void ThrowsBusinessExceptionWithDefaultMessageSuccessfully()
        {
            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                throw new BusinessException();
            });

            Assert.AreEqual("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(0, exception.Errors.Count);
        }

        [TestMethod]
        public void ThrowsBusinessExceptionWithCustomMessageSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";

            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                throw new BusinessException(message);
            });

            Assert.AreEqual(message, exception.Message);
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(0, exception.Errors.Count);
        }

        [TestMethod]
        public void ThrowsBusinessExceptionWithCustomMessageAndErrorsSuccessfully()
        {
            string message = "MESSAGE TO ESCEPTION";

            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                throw new BusinessException(message, "Error1", "Error2");
            });

            Assert.AreEqual(message, exception.Message);
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(2, exception.Errors.Count);
        }

        [TestMethod]
        public void ThrowsBusinessExceptionWithDefaultMessageAndErrorsSuccessfully()
        {
            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                throw new BusinessException(new string[] { "Error1", "Error2" });
            });

            Assert.AreEqual("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(2, exception.Errors.Count);
            Assert.AreEqual("Error1", exception.Errors.ElementAt(0));
            Assert.AreEqual("Error2", exception.Errors.ElementAt(1));
        }

        [TestMethod]
        public void ThrowsBusinessExceptionWithException()
        {
            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex);
                }
            });

            Assert.AreEqual("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.IsNotNull(exception.InnerException);
            Assert.AreEqual(typeof(Exception), exception.InnerException.GetType());
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(0, exception.Errors.Count);
        }

        [TestMethod]
        public void ThrowsBusinessExceptionWithExceptionAndErrors()
        {
            BusinessException exception = Assert.ThrowsException<BusinessException>(() =>
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex, "Error1", "Error2");
                }
            });

            Assert.AreEqual("One or more errors occurs. Check internal errors.", exception.Message);
            Assert.IsNotNull(exception.InnerException);
            Assert.AreEqual(typeof(Exception), exception.InnerException.GetType());
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(2, exception.Errors.Count);
            Assert.AreEqual("Error1", exception.Errors.ElementAt(0));
            Assert.AreEqual("Error2", exception.Errors.ElementAt(1));
        }
    }
}
