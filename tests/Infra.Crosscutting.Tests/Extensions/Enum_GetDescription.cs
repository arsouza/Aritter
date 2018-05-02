using FluentAssertions;
using System;
using System.ComponentModel;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Enum_GetDescription
    {
        [Fact]
        public void GivenEnumWithDescriptionThenReturnDescription()
        {
            Enum1 value1 = Enum1.Value1;
            string description = value1.GetDescription();

            description.Should().NotBeNull().And.Be("Value1");
        }

        [Fact]
        public void GivenEnumWithoutDescriptionThenReturnDefaultValueImplicit()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDescription();

            description.Should().NotBeNull().And.Be("Value2");
        }

        [Fact]
        public void GivenEnumWithoutDescriptionThenReturnDefaultValueExplicit()
        {
            Enum1 value2 = Enum1.Value2;
            string description = value2.GetDescription("Value2");

            description.Should().NotBeNull().And.Be("Value2");
        }

        private enum Enum1
        {
            [Description("Value1")]
            Value1,
            Value2
        }
    }
}
