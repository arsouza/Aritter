using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_PadRight
    {
        [Fact]
        public void ReturnPaddedGivenValidString()
        {
            string text = "padding";
            string paddedText = text.PadRight(5, "0");

            paddedText.Should().NotBeNull().And.Be("padding00000");
        }

        [Fact]
        public void ReturnPaddedGivenNull()
        {
            string text = null;
            string paddedText = text.PadLeft(5, "0");

            paddedText.Should().NotBeNull().And.Be("00000");
        }

        [Fact]
        public void ReturnPaddedGivenEmpty()
        {
            string text = "";
            string paddedText = text.PadLeft(5, "0");

            paddedText.Should().NotBeNull().And.Be("00000");
        }
    }
}
