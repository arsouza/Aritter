using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace Aritter.API.Tests.API
{
    internal class AritterAuthenticator : IAuthenticator
    {
        private readonly string username;
        private readonly string password;

        public AritterAuthenticator(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return;
            }

            var authorizeRequest = new RestRequest("token", Method.POST);
            authorizeRequest.AddParameter("text/plain", string.Format("grant_type=password&username={0}&password={1}", username, password), ParameterType.RequestBody);

            var authorizeResponse = new RestClient(client.BaseUrl).Execute<Dictionary<string, object>>(authorizeRequest);

            var accessToken = authorizeResponse.Data["access_token"].ToString();

            request.AddParameter("Authorization", accessToken, ParameterType.HttpHeader);
        }
    }
}
