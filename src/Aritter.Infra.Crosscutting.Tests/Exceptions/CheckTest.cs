using Aritter.Infra.Crosscutting.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aritter.Infra.Crosscutting.Tests.Exceptions
{
    [TestClass]
    public class CheckTest
    {
        [TestMethod]
        public void CallAgainstWithBoolAssertionAndMessageShouldNotThrowAnException()
        {
            Check.Against<Exception>(false, "Message");
        }

        [TestMethod]
        public void CallAgainstWithBoolAssertionAndMessageShouldThrowAnException()
        {
            Exception exception = Assert.ThrowsException<Exception>(() =>
            {
                Check.Against<Exception>(true, "Message");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(Exception));
            Assert.AreEqual("Message", exception.Message);
        }

        [TestMethod]
        public void CallAgainstWithFuncAssertionAndMessageShouldNotThrowAnException()
        {
            Check.Against<Exception>(() => { return false; }, "Message");
        }

        [TestMethod]
        public void CallAgainstWithFuncAssertionAndMessageShouldThrowAnException()
        {
            Exception exception = Assert.ThrowsException<Exception>(() =>
            {
                Check.Against<Exception>(() => { return true; }, "Message");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(Exception));
            Assert.AreEqual("Message", exception.Message);
        }

        [TestMethod]
        public void CallIsTypeOfShouldNotThrowAnException()
        {
            Check.IsTypeOf<String>("test", "Message");
        }

        [TestMethod]
        public void CallIsTypeOfShouldThrowAnException()
        {
            InvalidOperationException exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                Check.IsTypeOf<String>(1, "Message");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(Exception));
            Assert.AreEqual("Message", exception.Message);
        }

        [TestMethod]
        public void CallAreEqualsShouldNotThrowAnException()
        {
            Check.AreEquals<Exception>("test", "test", "Message");
        }

        [TestMethod]
        public void CallAreEqualsShouldThrowAnException()
        {
            Exception exception = Assert.ThrowsException<Exception>(() =>
            {
                Check.AreEquals<Exception>("test", "no-test", "Message");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(Exception));
            Assert.AreEqual("Message", exception.Message);
        }

        [TestMethod]
        public void CallIsNullShouldNotThrowAnException()
        {
            Check.IsNull(null, "Message");
        }

        [TestMethod]
        public void CallIsNullShouldThrowAnException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Check.IsNull("test", "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
            Assert.AreEqual("value", (exception as ArgumentNullException).ParamName);
        }

        [TestMethod]
        public void CallIsNotNullShouldNotThrowAnException()
        {
            Check.IsNotNull("Test", "Message");
        }

        [TestMethod]
        public void CallIsNotNullShouldThrowAnException()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Check.IsNotNull(null, "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            Assert.AreEqual("value", exception.ParamName);
        }

        [TestMethod]
        public void CallIsNotEmptyShouldNotThrowAnException()
        {
            Check.IsNotEmpty("Test", "Message");
        }

        [TestMethod]
        public void CallIsNotEmptySendEmptyShouldThrowAnException()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Check.IsNotEmpty("", "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            Assert.AreEqual("value", exception.ParamName);
        }

        [TestMethod]
        public void CallIsNotEmptySendNullShouldThrowAnException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Check.IsNotEmpty(null, "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
            Assert.AreEqual("value", exception.ParamName);
        }

        [TestMethod]
        public void CallIsNotEmptyEnumerableShouldNotThrowAnException()
        {
            Check.IsNotEmpty(new int[] { 1 }, "Message");
        }

        [TestMethod]
        public void CallIsNotEmptyEnumerableSendEmptyShouldThrowAnException()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Check.IsNotEmpty(new int[] { }, "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            Assert.AreEqual("value", exception.ParamName);
        }

        [TestMethod]
        public void CallIsNotEmptyEnumerableSendNullShouldThrowAnException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Check.IsNotEmpty<int>(null, "value");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
            Assert.AreEqual("value", exception.ParamName);
        }
    }
}
