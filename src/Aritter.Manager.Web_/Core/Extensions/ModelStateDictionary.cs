using Aritter.Manager.Web.Core.Aggregates;
using System.Linq;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		public static void AddModelStateInfo(this ModelStateDictionary dictionary, string info)
		{
			AddModelStateMessage(dictionary, ModelStateType.Info, info);
		}

		public static void AddModelStateError(this ModelStateDictionary dictionary, string error)
		{
			AddModelStateMessage(dictionary, ModelStateType.Error, error);
		}

		public static void AddModelStateWarning(this ModelStateDictionary dictionary, string warning)
		{
			AddModelStateMessage(dictionary, ModelStateType.Warning, warning);
		}

		public static void AddModelStateSuccess(this ModelStateDictionary dictionary, string message)
		{
			AddModelStateMessage(dictionary, ModelStateType.Success, message);
		}

		private static void AddModelStateMessage(ModelStateDictionary modelState, ModelStateType type, string message)
		{
			var key = string.Format("{0}", type);

			ModelState model;

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