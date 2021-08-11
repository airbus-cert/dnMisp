using dnMisp.Misc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace dnMisp
{
    public abstract class HttpRestConsumer
        : HttpClient
    {
        private const string EXCEPT_URI_INVALID = "The URI is not valid.";

        public HttpClientHandler ClientHandler { get; set; }
        #region Ctors
        public HttpRestConsumer()
            : this(MaxConnectionsPerServer: 4)
        {
        }

        public HttpRestConsumer(HttpClientHandler handler)
            : base(handler)
        {
            ClientHandler = handler;
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public HttpRestConsumer(int MaxConnectionsPerServer)
            : this(new HttpClientHandler { MaxConnectionsPerServer = MaxConnectionsPerServer })
        {
        }

        public HttpRestConsumer(Uri baseUri, int MaxConnectionsPerServer = 4)
            : this(MaxConnectionsPerServer)
        {
            Init(baseUri);
        }

        public HttpRestConsumer(string baseUri, int MaxConnectionsPerServer = 4)
            : this(MaxConnectionsPerServer)
        {
            Init(baseUri);
        }


        protected void Init(Uri baseUri)
        {
            BaseAddress = baseUri;
            Timeout = new TimeSpan(1, 0, 0);
        }

        protected void Init(string baseUri)
        {
            Uri baseAdd;

            if (!Uri.TryCreate(baseUri, UriKind.Absolute, out baseAdd))
                throw new ArgumentException(EXCEPT_URI_INVALID, nameof(baseUri));

            Init(baseAdd);
        }
        #endregion

        public new async Task<string> GetAsync(string relativeUrl)
        {
            HttpResponseMessage response = await base.GetAsync(relativeUrl);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> GetAsync<T>(string relativeUrl)
        {
            HttpResponseMessage response = await base.GetAsync(relativeUrl);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<R> PostAsync<R>(string relativeUrl, object data)
        {
            HttpResponseMessage response = await HttpClientExtensions.PostAsync(this, relativeUrl, data, JsonHelper.Formatter);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<R>();
        }


        public async Task<string> PostAsync(string relativeUrl, object data)
        {
            Debug.WriteLine(relativeUrl);

            HttpResponseMessage response = await HttpClientExtensions.PostAsync(this, relativeUrl, data, JsonHelper.Formatter);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string relativeUrl)
        {
            StringContent stringContent = new StringContent(string.Empty);
            HttpResponseMessage response = await base.PostAsync(relativeUrl, stringContent);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public new async Task<HttpStatusCode> DeleteAsync(string relativeUrl)
        {
            HttpResponseMessage response = await base.DeleteAsync(relativeUrl);
            return response.StatusCode;
        }
    }
}
