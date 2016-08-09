using Aritter.Infra.Crosscutting.Exceptions;
using RestSharp;
using System;

namespace Aritter.API.Tests.API
{
    public class AritterApi : IDisposable
    {
        const string BaseUrl = "http://localhost/Aritter.API/api";

        private string username;
        private string password;

        public static IRestRequest CurrentRequest { get; private set; }
        public static IRestResponse CurrentResponse { get; private set; }

        public AritterApi()
        {
        }

        public AritterApi(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            CurrentRequest = request;

            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            client.Authenticator = new AritterAuthenticator(username, password);

            var response = CurrentResponse = client.Execute<T>(request);

            Check.IsNull(CurrentResponse.ErrorException, "Error retrieving response. Check inner details for more info.");

            return (IRestResponse<T>)response;
        }

        #region IDisposable Support

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    CurrentRequest = null;
                    CurrentResponse = null;
                }

                username = null;
                password = null;

                disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
