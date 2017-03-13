using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
