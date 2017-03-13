using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class CultureInfoTest
    {
        [TestMethod]

        public void CallIsEqualMustReturnTrue()
        {
            CultureInfo culture1 = new CultureInfo("pt-BR");
            CultureInfo culture2 = new CultureInfo("pt-BR");

            bool isEqual = culture1.IsEqual(culture2);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]

        public void CallIsEqualMustReturnFalse()
        {
            CultureInfo culture1 = new CultureInfo("pt-BR");
            CultureInfo culture2 = new CultureInfo("en-US");

            bool isEqual = culture1.IsEqual(culture2);

            Assert.IsFalse(isEqual);
        }
    }
}