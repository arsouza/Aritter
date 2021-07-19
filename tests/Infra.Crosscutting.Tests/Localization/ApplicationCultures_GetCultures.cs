using System.Globalization;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Localization;
using Xunit;

namespace Infra.Crosscutting.Tests.Localization
{
    public class ApplicationCultures_GetCultures
    {
        [Fact]
        public void GetCulturesSuccessfully()
        {
            CultureInfo ptbr = ApplicationCultures.Portugues;
            ptbr.Should().NotBeNull();
            ptbr.Name.Should().Be("pt-BR");

            CultureInfo enus = ApplicationCultures.English;
            enus.Should().NotBeNull();
            enus.Name.Should().Be("en-US");
        }
    }
}
