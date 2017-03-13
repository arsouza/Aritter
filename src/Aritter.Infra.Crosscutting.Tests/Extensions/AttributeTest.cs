using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void GetAttributeFromEnumTypeMustReturnAttributeSuccessfully()
        {
            AttrEnumTest enumValue = AttrEnumTest.Value;
            DisplayAttribute attribute = enumValue.GetAttributeFromEnumType<DisplayAttribute>();

            Assert.IsNotNull(attribute);
            Assert.IsInstanceOfType(attribute, typeof(DisplayAttribute));
            Assert.AreEqual("Value", attribute.Name);
        }

        private enum AttrEnumTest
        {
            [Display(Name = "Value")]
            Value = 0
        }
    }
}
