using Aritter.API.Tests.API;
using Aritter.Infra.Data.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Aritter.API.Tests.Steps
{
    [Binding]
    internal class BaseSteps
    {
        private IRestResponse<object> response;
        private RestRequest request;

        [Given(@"I have cleaned the database")]
        public void GivenIHaveCleanedTheDatabase()
        {
            using (var context = new AritterContext())
            {
                context.Database.ExecuteSqlCommand(@"EXEC sp_MSForEachTable @Command1 = 'DISABLE TRIGGER ALL ON ?';
                                                     EXEC sp_MSForEachTable @Command1 = 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';
                                                     EXEC sp_MSForEachTable @Command1 = 'DELETE FROM ?';
													 EXEC sp_MSForEachTable @Command1 = 'IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE OBJECTPROPERTY(OBJECT_ID(''?''), ''TableHasIdentity'') = 1 AND TABLE_TYPE = ''BASE TABLE'') BEGIN DBCC CHECKIDENT(''?'', RESEED, 0); END';
                                                     EXEC sp_MSForEachTable @Command1 = 'ALTER TABLE ? CHECK CONSTRAINT ALL';
                                                     EXEC sp_MSForEachTable @Command1 = 'ENABLE TRIGGER ALL ON ?';");
            }
        }

        [Given(@"I have a request content '(.*)' like text as '(.*)'")]
        public void GivenIHaveARequestContentLikeTextAs(string content, string method)
        {
            var httpMethod = (Method)Enum.Parse(typeof(Method), method.ToUpper(CultureInfo.CurrentCulture));

            request = new RestRequest(httpMethod);
            request.AddParameter("text/plain", content, ParameterType.RequestBody);
        }


        [Given(@"I have a request content '(.*)' like json as '(.*)'")]
        public void GivenIHaveARequestContentLikeJsonAs(string content, string method)
        {
            var httpMethod = (Method)Enum.Parse(typeof(Method), method.ToUpper(CultureInfo.CurrentCulture));

            request = new RestRequest(httpMethod);
            request.AddParameter("application/json", content, ParameterType.RequestBody);
        }

        [When(@"I send to the '(.*)' resource")]
        public void WhenISendToTheResource(string resource)
        {
            using (var api = new AritterApi())
            {
                request.Resource = resource;
                response = api.Execute<object>(request);
            }
        }

        [Then(@"the result should be a '(.*)' status code")]
        public void ThenTheResultShouldBeAStatusCode(string statusCode)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(statusCode, response.StatusCode.ToString());
        }
    }
}
