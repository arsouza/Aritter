using TechTalk.SpecFlow;

namespace Aritter.API.Tests.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWithScenarioContext(this string text)
        {
            var formatedString = text;

            foreach (var key in ScenarioContext.Current.Keys)
            {
                formatedString = formatedString.Replace("{" + key + "}", ScenarioContext.Current[key].ToString());
            }

            return formatedString;
        }
    }
}
