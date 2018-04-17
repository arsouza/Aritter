using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using System.ComponentModel;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Enum_GetDisplayName
    {
        [Fact]
        public void GivenEnumWithDisplayNameThenReturnDisplayName()
        {
            Enum1 value1 = Enum1.Value1;
            string description = value1.GetDisplayName();

            description.Should().NotBeNull().And.Be("Name");
        }

        [Fact]
        public void GivenEnumWithoutDisplayNameThenReturnDefaultValueImplicit()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDisplayName();

            description.Should().NotBeNull().And.Be("Value2");
        }

        [Fact]
        public void GivenEnumWithoutDisplayNameThenReturnDefaultValue()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDisplayName("Value2");

            description.Should().NotBeNull().And.Be("Value2");
        }

        private enum Enum1
        {
            [DisplayName("Name")]
            Value1,
            Value2
        }
    }
}
