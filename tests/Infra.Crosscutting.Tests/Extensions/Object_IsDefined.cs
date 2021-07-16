using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Object_IsDefined
    {
        [Fact]
        public void ReturnTrueGivenDefinedAttribute()
        {
            var object1 = new TestObject1 { Id = 1 };
            bool isDefined = object1.IsDefined<DisplayAttribute>();

            isDefined.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseGivenNotDefinedAttribute()
        {
            var object1 = new TestObject1 { Id = 1 };
            bool isDefined = object1.IsDefined<DescriptionAttribute>();

            isDefined.Should().BeFalse();
        }
    }
}
