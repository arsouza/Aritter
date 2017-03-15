using Aritter.Infra.Crosscutting.Extensions;
using System.ComponentModel;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{

    public class Enum_GetDescription
    {
        [Fact]
        public void ReturnDescriptionGivenEnumWithDescription()
        {
            Enum1 value1 = Enum1.Value1;
            string description = value1.GetDescription();

            Assert.NotNull(description);
            Assert.NotEqual("", description);
            Assert.Equal("Value1", description);
        }

        [Fact]
        public void ReturnEmptyGivenEnumWithoutDescription()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDescription();

            Assert.NotNull(description);
            Assert.Equal("", description);
        }

        [Fact]
        public void ReturnDefaultValueGivenEnumWithoutDescription()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDescription("Value2");

            Assert.NotNull(description);
            Assert.Equal("Value2", description);
        }

        private enum Enum1
        {
            [Description("Value1")]
            Value1,            
            Value2
        }
    }
}
