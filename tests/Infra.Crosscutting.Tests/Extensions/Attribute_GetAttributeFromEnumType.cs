using FluentAssertions;
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

            attribute.Should().NotBeNull().And.BeOfType<DisplayAttribute>();
            attribute.Name.Should().Be("Value");
        }

        [Fact]
        public void ReturnNullGivenEnumWithoutAttribute()
        {
            AttrEnumTest enumValue = AttrEnumTest.Text;
            DisplayAttribute attribute = enumValue.GetAttributeFromEnumType<DisplayAttribute>();

            attribute.Should().BeNull();
        }

        private enum AttrEnumTest
        {
            [Display(Name = "Value")]
            Value = 0,

            Text = 1
        }
    }
}
