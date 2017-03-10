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

        public void CallInheritsFromShouldNotThrowAnException()
        {
            Check.InheritsFrom<int>(1, "Message");
        }

        [TestMethod]
        public void CallInheritsFromShouldThrowAnException()
        {
            InvalidOperationException exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                Check.InheritsFrom<string>(1, "Message");
            });

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
            Assert.AreEqual("Message", exception.Message);
        }
    }
}
