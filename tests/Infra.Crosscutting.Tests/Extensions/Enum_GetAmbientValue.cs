using FluentAssertions;
using System;
using System.ComponentModel;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Enum_GetAmbientValue
    {
        [Fact]
        public void GivenEnumWithAmbientValueThenReturnObjectString()
        {
            Enum1 value1 = Enum1.Value1;
            object value = value1.GetAmbientValue();

            value.Should().NotBeNull().And.Be("Name");
        }

        [Fact]
        public void GivenEnumWithAmbientValueThenReturnString()
        {
            Enum1 value1 = Enum1.Value1;
            string value = value1.GetAmbientValue<string>();

            value.Should().NotBeNull().And.Be("Name");
        }

        [Fact]
        public void GivenEnumWithStringAmbientValueThenThrowsInvalidCastException()
        {
            Action act = () =>
            {
                Enum1 value1 = Enum1.Value1;
                value1.GetAmbientValue<bool>();
            };

            act.Should().Throw<InvalidCastException>().And.Message.Should().Be("The value must be an 'Boolean' type");
        }

        [Fact]
        public void GivenEnumWithIntAmbientValueThenThrowsInvalidCastException()
        {
            Action act = () =>
            {
                Enum1 value1 = Enum1.Value2;
                value1.GetAmbientValue<bool>();
            };

            act.Should().Throw<InvalidCastException>().And.Message.Should().Be("The value must be an 'Boolean' type");
        }

        [Fact]
        public void GivenEnumWithBooleanAmbientValueThenThrowsInvalidCastException()
        {
            Action act = () =>
            {
                Enum1 value1 = Enum1.Value3;
                value1.GetAmbientValue<int>();
            };

            act.Should().Throw<InvalidCastException>().And.Message.Should().Be("The value must be an 'Int32' type");
        }

        [Fact]
        public void GivenEnumWithAmbientValueThenReturnInt()
        {
            Enum1 value2 = Enum1.Value2;
            int value = value2.GetAmbientValue<int>();

            value.Should().Be(3);
        }

        [Fact]
        public void GivenEnumWithoutAmbientValueThenReturnObjectInt()
        {
            Enum1 value2 = Enum1.Value2;
            object value = value2.GetAmbientValue();

            value.Should().Be(3);
        }

        [Fact]
        public void GivenEnumWithAmbientValueThenReturnBoolean()
        {
            Enum1 value2 = Enum1.Value3;
            bool value = value2.GetAmbientValue<bool>();

            value.Should().Be(true);
        }

        [Fact]
        public void GivenEnumWithoutAmbientValueThenReturnNull()
        {
            Enum1 value2 = Enum1.Value4;
            object value = value2.GetAmbientValue();

            value.Should().BeNull();
        }

        private enum Enum1
        {
            [AmbientValue("Name")]
            Value1,
            [AmbientValue(3)]
            Value2,
            [AmbientValue(true)]
            Value3,
            Value4,
            Value5
        }
    }
}
