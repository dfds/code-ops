using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class DeleteBuildRequest : ApiRequest
    {
        public DeleteBuildRequest(string organization, string project, int buildId)
        {
            ApiVersion = "6.1-preview.7";
            Method = HttpMethod.Delete;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/builds/{buildId}?api-version={ApiVersion}");
        }
    }
}
