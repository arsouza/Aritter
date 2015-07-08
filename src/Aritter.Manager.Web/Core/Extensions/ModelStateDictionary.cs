using Aritter.Manager.Web.Core.Aggregates;
using System.Linq;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		public static void AddModelStateInfo(this ModelStateDictionary dictionary, string info)
		{
			AddModelStateInfo(dictionary, null, info);
		}

		public static void AddModelStateInfo(this ModelStateDictionary dictionary, string title, string info)
		{
			AddModelStateMessage(dictionary, ModelStateType.Info, title, info);
		}

		public static void AddModelStateError(this ModelStateDictionary dictionary, string error)
		{
			AddModelStateError(dictionary, null, error);
		}

		public static void AddModelStateError(this ModelStateDictionary dictionary, string title, string info)
		{
			AddModelStateMessage(dictionary, ModelStateType.Error, title, info);
		}

		public static void AddModelStateWarning(this ModelStateDictionary dictionary, string warning)
		{
			AddModelStateWarning(dictionary, null, warning);
		}

		public static void AddModelStateWarning(this ModelStateDictionary dictionary, string title, string info)
		{
			AddModelStateMessage(dictionary, ModelStateType.Warning, title, info);
		}

		public static void AddModelStateSuccess(this ModelStateDictionary dictionary, string message)
		{
			AddModelStateSuccess(dictionary, null, message);
		}

		public static void AddModelStateSuccess(this ModelStateDictionary dictionary, string title, string info)
		{
			AddModelStateMessage(dictionary, ModelStateType.Success, title, info);
		}

		private static void AddModelStateMessage(ModelStateDictionary modelState, ModelStateType type, string title, string message)
		{
			var key = string.Format("{0}", type);

			ModelState model = null;

			if (modelState.Any(p => p.Key == key))
			{
				model = modelState
					.Where(p => p.Key == key)
					.Select(p => p.Value)
					.First();

				model.Errors.Add(message);
			}
			else
			{
				model = new ModelState();
				model.Errors.Add(message);

				modelState.Add(key, model);
			}
		}
	}
}