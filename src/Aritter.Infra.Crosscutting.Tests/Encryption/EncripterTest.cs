using System;
using Aritter.Infra.Crosscutting.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Cosscutting.Tests
{
    [TestClass]
    public class EncrypterTest
    {
        [TestMethod]
        public void EncryptSuccessfully()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.AreNotEqual(null, encrytedValue);
            Assert.AreNotEqual("", encrytedValue);
        }

        [TestMethod]
        public void DecryptSuccessfully()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.AreNotEqual(null, encrytedValue);
            Assert.AreNotEqual("", encrytedValue);

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            Assert.AreNotEqual(null, decryptedValue);
            Assert.AreNotEqual("", decryptedValue);
            Assert.AreEqual(value, decryptedValue);
        }

        [TestMethod]
        public void EncryptNullValueMustReturnNull()
        {
            string encrytedValue = Encrypter.Encrypt(null);
            Assert.IsNull(encrytedValue);
        }

        [TestMethod]
        public void EncryptEmptyValueMustReturnNull()
        {
            string encrytedValue = Encrypter.Encrypt("");
            Assert.IsNull(encrytedValue);
        }

        [TestMethod]
        public void DecryptNullValueMustReturnNull()
        {
            string decrytedValue = Encrypter.Decrypt(null);
            Assert.IsNull(decrytedValue);
        }

        [TestMethod]
        public void DecryptEmptyValueMustReturnNull()
        {
            string decrytedValue = Encrypter.Decrypt("");
            Assert.IsNull(decrytedValue);
        }

        [TestMethod]
        public void SetPrivateKeySuccessfully()
        {
            var privateKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
            string value = "VALUE_TO_ENCRYPT";

            Encrypter.SetPrivateKey(privateKey);

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.AreNotEqual(null, encrytedValue);
            Assert.AreNotEqual("", encrytedValue);

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            Assert.AreNotEqual(null, decryptedValue);
            Assert.AreNotEqual("", decryptedValue);
            Assert.AreEqual(value, decryptedValue);
        }

        [TestMethod]
        public void SetNullPrivateKeyMustThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Encrypter.SetPrivateKey(null);
            });

            Assert.AreEqual(exception.ParamName, "key");
        }

        [TestMethod]
        public void SetEmptyPrivateKeyMustThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Encrypter.SetPrivateKey("");
            });

            Assert.AreEqual(exception.ParamName, "key");
        }
    }
}