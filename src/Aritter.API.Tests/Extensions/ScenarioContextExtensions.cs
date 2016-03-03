using TechTalk.SpecFlow;

namespace Aritter.API.Tests.Extensions
{
    public static class ScenarioContextExtensions
    {
        public static void AddValue(this ScenarioContext scenarioContext, string key, object value)
        {
            if (scenarioContext == null)
            {
                return;
            }

            if (scenarioContext.ContainsKey(key))
            {
                scenarioContext.Remove(key);
            }

            scenarioContext.Add(key, value);
        }
    }
}
