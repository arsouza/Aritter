using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Enum_GetDisplayName
    {
        [Fact]
        public void GivenEnumWithDisplayNameThenReturnDisplayName()
        {
            Enum1 value1 = Enum1.Value1;
            string displayName = value1.GetDisplayName();

            displayName.Should().NotBeNull().And.Be("Value1DisplayName");
        }

        [Fact]
        public void GivenEnumWithoutDisplayNameThenReturnDefaultValueImplicit()
        {
            Enum1 value2 = Enum1.Value2;
            string displayName = value2.GetDisplayName();

            displayName.Should().NotBeNull().And.Be("Value2");
        }

        [Fact]
        public void GivenEnumWithoutDisplayNameThenReturnDefaultValueExplicit()
        {
            Enum1 value2 = Enum1.Value2;
            string displayName = value2.GetDisplayName("Value2");

            displayName.Should().NotBeNull().And.Be("Value2");
        }

        private enum Enum1
        {
            [Display(Name = "Value1DisplayName")]
            Value1,
            Value2
        }
    }
}
