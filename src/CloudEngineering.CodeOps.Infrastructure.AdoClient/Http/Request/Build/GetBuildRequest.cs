using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Http.Request.Build
{
    public sealed class GetBuildRequest : ApiRequest
    {
        public GetBuildRequest(string organization, string project, int buildId)
        {
            ApiVersion = "6.1-preview.6";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/{buildId}?api-version={ApiVersion}");
        }
    }
}
