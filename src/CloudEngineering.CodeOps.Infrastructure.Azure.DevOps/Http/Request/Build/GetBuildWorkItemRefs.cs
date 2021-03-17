using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class GetBuildWorkItemRefs : ApiRequest
    {
        public GetBuildWorkItemRefs(string organization, string project, int buildId)
        {
            ApiVersion = "6.1-preview.2";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/builds/{buildId}/workitems?api-version={ApiVersion}");
        }
    }
}
