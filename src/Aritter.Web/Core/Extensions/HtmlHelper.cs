using Aritter.Infra.CrossCutting.Extensions;
using Aritter.Web.Core.Aggregates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Aritter.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		public static MvcHtmlString ModelStateSummary(this HtmlHelper html)
		{
			return ModelStateSummary(html, null);
		}

		public static MvcHtmlString ModelStateSummary(this HtmlHelper html, object htmlAttributes)
		{
			var messages = GetModelStateMessages(html);

			if (!messages.Any())
				return null;

			var alerts = new StringBuilder();

			foreach (var message in messages)
			{
				alerts.AppendLine(GetAlertMessage(message, htmlAttributes));
			}

			return MvcHtmlString.Create(alerts.ToString());
		}

		private static string GetAlertMessage(KeyValuePair<string, ModelState> message, object htmlAttributes)
		{
			var messageType = message.Key.AsEnum<ModelStateType>();

			var div = CreateAlertDiv(htmlAttributes, messageType);
			var button = CreateAlertButton();

			div.InnerHtml += button.ToString(TagRenderMode.Normal);

			var h4 = CreateAlertTitle(messageType);

			div.InnerHtml += h4.ToString(TagRenderMode.Normal);

			var ul = CreateAlertMessageList(message);

			div.InnerHtml += ul.ToString(TagRenderMode.Normal);

			return div.ToString(TagRenderMode.Normal);
		}

		private static TagBuilder CreateAlertMessageList(KeyValuePair<string, ModelState> message)
		{
			var ul = new TagBuilder("ul");

			foreach (var error in message.Value.Errors)
			{
				var li = new TagBuilder("li");
				li.InnerHtml += error.ErrorMessage;
				ul.InnerHtml += li.ToString(TagRenderMode.Normal);
			}

			return ul;
		}

		private static TagBuilder CreateAlertTitle(ModelStateType messageType)
		{
			var h4 = new TagBuilder("h4");

			var i = new TagBuilder("i");
			i.AddCssClass(string.Format("icon fa fa-{0}", GetMessageIcon(messageType)));

			h4.InnerHtml = i.ToString(TagRenderMode.Normal);
			h4.InnerHtml += string.Empty;
			return h4;
		}

		private static TagBuilder CreateAlertButton()
		{
			var button = new TagBuilder("button");
			button.Attributes.Add("type", "button");
			button.Attributes.Add("class", "close");
			button.Attributes.Add("data-dismiss", "alert");
			button.Attributes.Add("aria-hidden", "true");
			button.InnerHtml = "&times;";
			return button;
		}

		private static TagBuilder CreateAlertDiv(object htmlAttributes, ModelStateType messageType)
		{
			var div = new TagBuilder("div");
			div.MergeCssClass(string.Format("alert {0} alert-dismissable", GetAlertType(messageType)));

			div.MergeAttributes(htmlAttributes);
			return div;
		}

		private static string GetMessageIcon(ModelStateType modelStateType)
		{
			switch (modelStateType)
			{
				case ModelStateType.Error:
					return "ban";
				case ModelStateType.Info:
					return "info";
				case ModelStateType.Warning:
					return "warning";
				default:
					return "check";
			}
		}

		private static string GetAlertType(ModelStateType modelStateType)
		{
			switch (modelStateType)
			{
				case ModelStateType.Error:
					return "alert-danger";
				case ModelStateType.Info:
					return "alert-info";
				case ModelStateType.Warning:
					return "alert-warning";
				default:
					return "alert-success";
			}
		}

		private static string GetMessageTitle(ModelStateType modelStateType)
		{
			switch (modelStateType)
			{
				case ModelStateType.Error:
					return "Erro!";
				case ModelStateType.Info:
					return "Informação!";
				case ModelStateType.Warning:
					return "Alerta!";
				default:
					return "Sucesso!";
			}
		}

		private static IEnumerable<KeyValuePair<string, ModelState>> GetModelStateMessages(HtmlHelper html)
		{
			return html.ViewData.ModelState
				.Where(p => p.Value.Errors.Any())
				.ToList();
		}
	}
}