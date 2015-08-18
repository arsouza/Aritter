using System;
using System.Text;

namespace Aritter.Infra.CrossCutting.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static string ConcatAllExceptions(this Exception ex)
		{
			return ConcatAllExceptions(ex, true);
		}

		public static string ConcatAllExceptions(this Exception ex, bool textWrap)
		{
			var result = new StringBuilder();
			string separator = string.Format("{0}>>> ", textWrap ? "\n" : string.Empty);

			result.Append(ex.Message);

			if (ex.InnerException != null)
			{
				result.AppendLine(separator);
				result.Append(ConcatAllExceptions(ex.InnerException));
			}

			return result.ToString();
		}

		#endregion Methods
	}
}