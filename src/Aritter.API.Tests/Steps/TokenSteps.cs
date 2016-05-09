using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Infra.Data.UnitOfWork;
using EntityFramework.BulkInsert.Extensions;
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
            var users = table.CreateSet<User>();

            using (var context = new AritterContext())
            {
                context.BulkInsert(users);
                context.SaveChanges();
            }
        }
    }
}
