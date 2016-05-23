using System;
using System.Diagnostics;

namespace Aritter.Infra.Crosscutting.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static TimeSpan Watch(this Action method)
		{
			if (method == null)
				throw new ArgumentNullException(nameof(method));

			var timer = new Stopwatch();
			timer.Start();

			method();

			timer.Stop();

			return timer.Elapsed;
		}

		#endregion Methods
	}
}