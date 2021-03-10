using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Protocols.Http
{
    public abstract class RestClient : HttpMessageInvoker, IRestClient
    {
        protected RestClient(HttpMessageHandler handler) : base(handler)
        {
        }

        protected RestClient(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
        }

        public async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        async Task<HttpResponseMessage> IRestClient.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await SendAsync(request, cancellationToken);
        }
    }
}
