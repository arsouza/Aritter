using FluentAssertions;
using Ritter.Infra.Crosscutting.Encryption;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests
{

    public class Encrypter_Encrypt
    {
        [Fact]
        public void ReturnEncryptedGivenAnyString()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            encrytedValue.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ReturnNullGivenNull()
        {
            string encrytedValue = Encrypter.Encrypt(null);
            encrytedValue.Should().BeNull();
        }

        [Fact]
        public void EncryptNullGivenEmpty()
        {
            string encrytedValue = Encrypter.Encrypt("");
            encrytedValue.Should().BeNull();
        }
    }
}
