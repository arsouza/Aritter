using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Aritter.Manager.Infrastructure
{
	public static class Encrypter
	{
		#region Fields

		private const string EncryptionKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

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

			var key = Convert.FromBase64String(EncryptionKey);
			var text = Convert.FromBase64String(value);

			var rijndael = new RijndaelManaged
			{
				KeySize = 256
			};

			var stream = new MemoryStream();
			var decryptor = new CryptoStream(stream, rijndael.CreateDecryptor(key, arrByte), CryptoStreamMode.Write);

			decryptor.Write(text, 0, text.Length);
			decryptor.FlushFinalBlock();

			var utf8 = new UTF8Encoding();

			return utf8.GetString(stream.ToArray());
		}

		public static string Encrypt(string value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			var key = Convert.FromBase64String(EncryptionKey);
			var text = new UTF8Encoding().GetBytes(value);

			var rijndael = new RijndaelManaged
			{
				KeySize = 256
			};

			var stream = new MemoryStream();
			var encryptor = new CryptoStream(stream, rijndael.CreateEncryptor(key, arrByte), CryptoStreamMode.Write);

			encryptor.Write(text, 0, text.Length);
			encryptor.FlushFinalBlock();

			return Convert.ToBase64String(stream.ToArray());
		}

		#endregion Methods
	}
}