using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Http.Request.Release
{
    public sealed class GetReleaseRequest : ApiRequest
    {
        public GetReleaseRequest(string organization, string projectIdentifier, int releaseId)
        {
            ApiVersion = "6.1-preview.8";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{projectIdentifier}/_apis/release/releases/{releaseId}?api-version={ApiVersion}");
        }
    }
}
