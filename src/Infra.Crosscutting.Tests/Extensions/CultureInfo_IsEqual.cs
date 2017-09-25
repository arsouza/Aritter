using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using System.Globalization;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{

    public class CultureInfo_IsEqual
    {
        [Fact]

        public void ReturnTrueGivenEqualCultures()
        {
            CultureInfo culture1 = new CultureInfo("pt-BR");
            CultureInfo culture2 = new CultureInfo("pt-BR");

            bool isEqual = culture1.IsEqual(culture2);

            isEqual.Should().BeTrue();
        }

        [Fact]

        public void ReturnFalseGivenNotEqualCultures()
        {
            CultureInfo culture1 = new CultureInfo("pt-BR");
            CultureInfo culture2 = new CultureInfo("en-US");

            bool isEqual = culture1.IsEqual(culture2);

            isEqual.Should().BeFalse();
        }
    }
}
