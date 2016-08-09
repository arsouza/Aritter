using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Diagnostics;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static TimeSpan Watch(this Action method)
        {
            Check.IsNotNull(method, nameof(method));

            var timer = new Stopwatch();

            timer.Start();
            method();
            timer.Stop();

            return timer.Elapsed;
        }

        #endregion Methods
    }
}