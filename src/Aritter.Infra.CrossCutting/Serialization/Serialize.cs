using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Aritter.Infra.CrossCutting.Serialization
{
	public static class Serialize
	{
		public static string ToBase64String(object data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			var formatter = new BinaryFormatter();

			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, data);

				var value = stream.ToArray();
				return Convert.ToBase64String(value);
			}
		}

		public static T FromBase64String<T>(string data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			var value = Convert.FromBase64String(data);
			var formatter = new BinaryFormatter();

			using (var stream = new MemoryStream(value))
			{
				try
				{
					var result = (T)formatter.Deserialize(stream);
					return result;
				}
				catch (Exception)
				{
					return default(T);
				}
			}
		}

		public static string ToXmlString(object value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			var xmlDoc = new XmlDocument();
			var xmlNamespaces = new XmlSerializerNamespaces();
			xmlNamespaces.Add(string.Empty, string.Empty);

			var xmlWriterSettings = new XmlWriterSettings
			{
				Indent = true,
				OmitXmlDeclaration = false,
				Encoding = Encoding.UTF8
			};

			using (var stream = new MemoryStream())
			{
				var xmlWriter = XmlWriter.Create(stream, xmlWriterSettings);
				var serializer = new XmlSerializer(value.GetType());

				serializer.Serialize(xmlWriter, value, xmlNamespaces);
				stream.Position = 0;

				var reader = new StreamReader(stream);

				xmlDoc.Load(reader);
			}

			return xmlDoc.InnerXml;
		}

		public static T FromXmlString<T>(string value)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T), string.Empty);

			byte[] byteArray = Encoding.ASCII.GetBytes(value.Replace(Environment.NewLine, string.Empty).Trim());
			MemoryStream stream = new MemoryStream(byteArray);

			T ret;
			StreamReader reader = new StreamReader(stream);

			ret = (T)serializer.Deserialize(reader);
			reader.Close();

			return ret;
		}
	}
}
