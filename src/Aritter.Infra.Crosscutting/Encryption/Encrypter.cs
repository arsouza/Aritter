using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Infra.Crosscutting.Encryption
{
    public static class Encrypter
    {
        #region Fields

        private static string privateKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        private static readonly byte[] arrByte =
        {
            0x50,
            0x08,
            0xF1,
            0xDD,
            0xDE,
            0x3C,
            0xF2,
            0x18,
            0x44,
            0x74,
            0x19,
            0x2C,
            0x53,
            0x49,
            0xAB,
            0xBC
        };

        #endregion Fields

        #region Methods

        public static string Decrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var key = Convert.FromBase64String(privateKey);
            var text = Convert.FromBase64String(value);

            var aes = Aes.Create();

            var stream = new MemoryStream();
            var decryptor = new CryptoStream(stream, aes.CreateDecryptor(key, arrByte), CryptoStreamMode.Write);

            decryptor.Write(text, 0, text.Length);
            decryptor.FlushFinalBlock();

            var utf8 = new UTF8Encoding();

            return utf8.GetString(stream.ToArray());
        }

        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var key = Convert.FromBase64String(privateKey);
            var text = new UTF8Encoding().GetBytes(value);

            var aes = Aes.Create();

            var stream = new MemoryStream();
            var encryptor = new CryptoStream(stream, aes.CreateEncryptor(key, arrByte), CryptoStreamMode.Write);

            encryptor.Write(text, 0, text.Length);
            encryptor.FlushFinalBlock();

            return Convert.ToBase64String(stream.ToArray());
        }

        public static void SetPrivateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            privateKey = key;
        }

        #endregion Methods
    }
}