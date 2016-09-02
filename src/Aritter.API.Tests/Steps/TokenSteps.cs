using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Aritter.API.Tests.Steps
{
    [Binding]
    public class TokenSteps
    {
        [Given(@"I created the users")]
        public void GivenICreatedTheUsers(Table table)
        {
            var users = table.CreateSet<UserAccount>();

            using (var context = new AritterContext())
            {
                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
