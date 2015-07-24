using System.Globalization;

namespace Aritter.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Fields

		private static readonly CultureInfo americanEnglish = new CultureInfo("en-US");
		private static readonly CultureInfo brazilPortuguese = new CultureInfo("pt-BR");
		private static readonly CultureInfo spainsSpanish = new CultureInfo("es-ES");

		#endregion Fields

		#region Properties

		public static CultureInfo AmericanEnglish
		{
			get { return americanEnglish; }
		}

		public static CultureInfo BrazilPortuguese
		{
			get { return brazilPortuguese; }
		}

		public static CultureInfo SpainsSpanish
		{
			get { return spainsSpanish; }
		}

		#endregion Properties

		#region Methods

		public static bool IsEqual(this CultureInfo culture, CultureInfo toCompare)
		{
			return culture.LCID == toCompare.LCID;
		}

		#endregion Methods
	}
}