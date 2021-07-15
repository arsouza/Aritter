using System.Globalization;

namespace Ritter.Infra.Crosscutting.Localization
{
    public static class ApplicationCultures
    {
        private static CultureInfo portugues = null;
        private static CultureInfo english = null;

        public static CultureInfo Portugues => (portugues = portugues ?? new CultureInfo("pt-BR"));
        public static CultureInfo English => (english = english ?? new CultureInfo("en-US"));
    }
}
