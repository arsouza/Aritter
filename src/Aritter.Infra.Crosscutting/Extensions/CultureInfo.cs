using System.Globalization;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static bool IsEqual(this CultureInfo culture, CultureInfo toCompare)
        {
            return culture.CompareInfo.Name == toCompare.CompareInfo.Name;
        }
    }
}
