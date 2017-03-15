using Xunit;
using Aritter.Infra.Crosscutting.Extensions;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_PadLeft
    {
        [Fact]
        public void ReturnPaddedGivenValidString()
        {
            string text = "padding";
            string paddedText = text.PadLeft(5, "0");

            Assert.NotNull(paddedText);
            Assert.NotEqual("", paddedText);
            Assert.Equal("00000padding", paddedText);
        }

        [Fact]
        public void ReturnPaddedGivenNull()
        {
            string text = null;
            string paddedText = text.PadLeft(5, "0");

            Assert.NotNull(paddedText);
            Assert.NotEqual("", paddedText);
            Assert.Equal("00000", paddedText);
        }

        [Fact]
        public void ReturnPaddedGivenEmpty()
        {
            string text = "";
            string paddedText = text.PadLeft(5, "0");

            Assert.NotNull(paddedText);
            Assert.NotEqual("", paddedText);
            Assert.Equal("00000", paddedText);
        }
    }
}
