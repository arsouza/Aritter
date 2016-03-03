using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Aritter.API.Tests.API
{
    public class AritterApi : IDisposable
    {
        const string BaseUrl = "http://localhost/Aritter.API/api";

        readonly string token;

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

        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AritterApi() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
