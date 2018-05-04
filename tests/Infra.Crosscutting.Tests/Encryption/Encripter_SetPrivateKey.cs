using Ritter.Infra.Crosscutting.Encryption;
using System;
using Xunit;
using FluentAssertions;

namespace Ritter.Infra.Crosscutting.Tests
{

    public class Encripter_SetPrivateKey
    {
        [Fact]
        public void SetPrivateKeySuccessfully()
        {
            var privateKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
            string value = "VALUE_TO_ENCRYPT";

            Encrypter.SetPrivateKey(privateKey);

            string encrytedValue = Encrypter.Encrypt(value);
            encrytedValue.Should().NotBeNullOrEmpty();

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            decryptedValue.Should().NotBeNullOrEmpty().And.Be(value);
        }

        [Fact]
        public void SetNullPrivateKeyMustThrowsArgumentNullException()
        {
            Action act = () => Encrypter.SetPrivateKey(null);
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("key");
        }

        [Fact]
        public void SetEmptyPrivateKeyMustThrowsArgumentNullException()
        {
            Action act = () => Encrypter.SetPrivateKey("");
            act.Should().Throw<ArgumentException>().And.ParamName.Should().Be("key");
        }
    }
}
