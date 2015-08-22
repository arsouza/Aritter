using System;
using System.Text;

namespace Aritter.Infra.CrossCutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static string GetFullMessage(this Exception exception)
        {
            var separator = string.Empty;
            var message = new StringBuilder();

            message.Append(exception.Message);

            if (exception.InnerException == null)
                return message.ToString();

            separator = string.Format("{0}Inner: ", Environment.NewLine);

            message.AppendLine(separator);
            message.Append(exception.InnerException.GetFullMessage());

            return message.ToString();
        }

        #endregion Methods
    }
}