using Ritter.Infra.Crosscutting.Extensions;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{

    public class Attribute_GetAttributeFromEnumType
    {
        [Fact]
        public void ReturnCorrectAttributeGivenEnumWithAttribute()
        {
            AttrEnumTest enumValue = AttrEnumTest.Value;
            DisplayAttribute attribute = enumValue.GetAttributeFromEnumType<DisplayAttribute>();

            Assert.NotNull(attribute);
            Assert.IsType<DisplayAttribute>(attribute);
            Assert.Equal("Value", attribute.Name);
        }

        [Fact]
        public void ReturnNullGivenEnumWithoutAttribute()
        {
            AttrEnumTest enumValue = AttrEnumTest.Text;
            DisplayAttribute attribute = enumValue.GetAttributeFromEnumType<DisplayAttribute>();

            Assert.Null(attribute);
        }

        private enum AttrEnumTest
        {
            [Display(Name = "Value")]
            Value = 0,

            Text = 1
        }
    }
}
