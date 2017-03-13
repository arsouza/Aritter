using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class Enum
    {
        [TestMethod]
        public void CallGetDescriptionSuccessfully()
        {
            EnumTest value1 = EnumTest.Value1;
            string description = value1.GetDescription();

            Assert.IsNotNull(description);
            Assert.AreNotEqual("", description);
            Assert.AreEqual("Value1", description);
        }

        [TestMethod]
        public void CallGetDescriptionMustReturnEmpty()
        {
            EnumTest value2 = EnumTest.Value2;
            string description = value2.GetDescription();

            Assert.IsNotNull(description);
            Assert.AreEqual("", description);
        }

        [TestMethod]
        public void CallGetDescriptionMustReturnDefaultValue()
        {
            EnumTest value2 = EnumTest.Value2;
            string description = value2.GetDescription("Value2");

            Assert.IsNotNull(description);
            Assert.AreEqual("Value2", description);
        }

        private enum EnumTest
        {
            [System.ComponentModel.Description("Value1")]
            Value1,            
            Value2
        }
    }
}
