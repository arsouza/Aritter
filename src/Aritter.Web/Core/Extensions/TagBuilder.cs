using Aritter.Manager.Infrastructure.Extensions;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		private static void MergeAttributes(this TagBuilder tag, object htmlAttributes)
		{
			if (htmlAttributes == null)
				return;

			var attributes = htmlAttributes.ToDictionary<string>();

			foreach (var attribute in attributes)
			{
				tag.Attributes[attribute.Key] += string.Format(" {0}", attribute.Value);
			}
		}

		private static void MergeCssClass(this TagBuilder tag, string value)
		{
			if (string.IsNullOrEmpty(value))
				return;

			if (tag.Attributes.ContainsKey("class"))
				tag.Attributes["class"] += string.Format(" {0}", value);
			else
				tag.AddCssClass(value);
		}
	}
}