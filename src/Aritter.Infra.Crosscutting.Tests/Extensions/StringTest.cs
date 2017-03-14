using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void CallToIsValidMailAddressWithNullValueMustReturnFalse()
        {
            string mailAddress = null;
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.IsFalse(isValidMailAddress);
        }

        [TestMethod]
        public void CallToIsValidMailAddressWithEmptyValueMustReturnFalse()
        {
            string mailAddress = "";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.IsFalse(isValidMailAddress);
        }

        [TestMethod]
        public void CallToIsValidMailAddressWithInvalidMailMustReturnFalse()
        {
            string mailAddress = "test@ff";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.IsFalse(isValidMailAddress);
        }

        [TestMethod]
        public void CallToIsValidMailAddressWithCalidMailMustReturnTrue()
        {
            string mailAddress = "test@ff.com";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.IsTrue(isValidMailAddress);
        }

        [TestMethod]
        public void CallPadLeftMustPadSomeText()
        {
            string text = "padding";
            string paddedText = text.PadLeft(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("00000padding", paddedText);
        }

        [TestMethod]
        public void CallPadLeftMustPadNullText()
        {
            string text = null;
            string paddedText = text.PadLeft(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("00000", paddedText);
        }

        [TestMethod]
        public void CallPadLeftMustPadEmptyText()
        {
            string text = "";
            string paddedText = text.PadLeft(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("00000", paddedText);
        }



        [TestMethod]
        public void CallPadRightMustPadSomeText()
        {
            string text = "padding";
            string paddedText = text.PadRight(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("padding00000", paddedText);
        }

        [TestMethod]
        public void CallPadRightMustPadNullText()
        {
            string text = null;
            string paddedText = text.PadLeft(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("00000", paddedText);
        }

        [TestMethod]
        public void CallPadRightMustPadEmptyText()
        {
            string text = "";
            string paddedText = text.PadLeft(5, "0");

            Assert.IsNotNull(paddedText);
            Assert.AreNotEqual("", paddedText);
            Assert.AreEqual("00000", paddedText);
        }
    }
}
