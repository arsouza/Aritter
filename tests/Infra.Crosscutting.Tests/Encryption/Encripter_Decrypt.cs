using FluentAssertions;
using Ritter.Infra.Crosscutting.Encryption;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests
{
    public class Encrypter_Decrypt
    {
        [Fact]
        public void ReturnDecryptedGivenAnyString()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            encrytedValue.Should().NotBeNullOrEmpty();

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            decryptedValue.Should().NotBeNullOrEmpty().And.Be(value);
        }

        [Fact]
        public void ReturnNullGivenNull()
        {
            string decrytedValue = Encrypter.Decrypt(null);
            decrytedValue.Should().BeNull();
        }

        [Fact]
        public void ReturnNullGivenEmpty()
        {
            string decrytedValue = Encrypter.Decrypt("");
            decrytedValue.Should().BeNull();
        }
    }
}
