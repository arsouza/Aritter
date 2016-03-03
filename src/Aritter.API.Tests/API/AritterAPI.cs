using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Aritter.API.Tests.API
{
    public class AritterApi : IDisposable
    {
        const string BaseUrl = "http://localhost/Aritter.API/api";

        private string token;

        public AritterApi()
        {
        }

        public AritterApi(string token)
        {
            this.token = token;
        }

        public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);

            if (!string.IsNullOrEmpty(token))
            {
                client.Authenticator = new HttpBasicAuthenticator(token, null);
            }

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                string message = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response;
        }

        #region IDisposable Support

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                token = null;

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
