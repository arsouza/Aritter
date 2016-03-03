using Aritter.API.Tests.API;
using Aritter.API.Tests.Extensions;
using Aritter.Infra.Data.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Aritter.API.Tests.Steps
{
    [Binding]
    internal class BaseSteps
    {
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

        [Given(@"I created a '(.*)' request with content '(.*)' like text")]
        public void GivenICreatedARequestWithContentLikeText(string method, string content)
        {
            var httpMethod = (Method)Enum.Parse(typeof(Method), method.ToUpper(CultureInfo.CurrentCulture));

            var request = new RestRequest(httpMethod);
            request.AddParameter("text/plain", content.FormatWithScenarioContext(), ParameterType.RequestBody);

            ScenarioContext.Current.AddValue(Constants.ApiRequest, request);
        }

        [Given(@"I create a '(.*)' request with content '(.*)' like json")]
        public void GivenICreateARequestWithContentLikeJson(string method, string content)
        {
            var httpMethod = (Method)Enum.Parse(typeof(Method), method.ToUpper(CultureInfo.CurrentCulture));

            var request = new RestRequest(httpMethod);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            ScenarioContext.Current.AddValue(Constants.ApiRequest, request);
        }

        [When(@"I send to the '(.*)' resource")]
        public void WhenISendToTheResource(string resource)
        {
            var request = ScenarioContext.Current.Get<RestRequest>(Constants.ApiRequest);

            using (var api = new AritterApi())
            {
                request.Resource = resource;
                var response = api.Execute<object>(request);
                ScenarioContext.Current.AddValue(Constants.ApiResponse, response);
            }
        }

        [Then(@"The result should be a '(.*)' status code")]
        public void ThenTheResultShouldBeAStatusCode(string statusCode)
        {
            var response = ScenarioContext.Current.Get<RestResponse<object>>(Constants.ApiResponse);

            Assert.IsNotNull(response);
            Assert.AreEqual(statusCode, response.StatusCode.ToString());
        }

        [Then(@"The result should contain")]
        public void ThenTheResultShouldContain(Table table)
        {
            var response = ScenarioContext.Current.Get<RestResponse<object>>(Constants.ApiResponse);

            Assert.IsNotNull(response);

            var data = (Dictionary<string, object>)response.Data;

            foreach (var row in table.Rows)
            {
                string jsonKey = row["JSONPath"];
                object jsonValue = null;

                Assert.IsTrue(data.TryGetValue(jsonKey, out jsonValue));
            }
        }

        [Then(@"The result should contain values")]
        public void ThenTheResultShouldContainValues(Table table)
        {
            var response = ScenarioContext.Current.Get<RestResponse<object>>(Constants.ApiResponse);

            Assert.IsNotNull(response);

            var data = (Dictionary<string, object>)response.Data;

            foreach (var row in table.Rows)
            {
                string jsonKey = row["JSONPath"];
                object jsonValue = null;

                Assert.IsTrue(data.TryGetValue(jsonKey, out jsonValue));

                Assert.IsNotNull(jsonValue);
                Assert.AreEqual(row["Value"].ToLower(CultureInfo.CurrentCulture), jsonValue.ToString().ToLower(CultureInfo.CurrentCulture));
            }
        }

        [Then(@"will store the JSON value")]
        public void ThenWillStoreTheJSONValue(Table table)
        {
            var response = ScenarioContext.Current.Get<RestResponse<object>>(Constants.ApiResponse);

            Assert.IsNotNull(response);

            var data = (Dictionary<string, object>)response.Data;

            foreach (var row in table.Rows)
            {
                object value = null;
                Assert.IsTrue(data.TryGetValue(row["JSONPath"], out value));

                ScenarioContext.Current.AddValue(row["Key"], value.ToString());
            }
        }

        [AfterScenario("ClearScenarioContext")]
        public void AfterScenario()
        {
            ScenarioContext.Current.Clear();
        }
    }
}
