using System.Net.Http;
using System.Net.Http.Headers;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request
{
    public abstract class ApiRequest : HttpRequestMessage
    {
        public string ApiVersion { get; protected set; }

        protected ApiRequest()
        {
            Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
