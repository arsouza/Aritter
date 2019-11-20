namespace System.Globalization
{
    public static class CultureInfoExtensions
    {
        public static bool IsEqual(this CultureInfo culture, CultureInfo toCompare)
        {
            return culture.CompareInfo.Name == toCompare.CompareInfo.Name;
        }
    }
}
