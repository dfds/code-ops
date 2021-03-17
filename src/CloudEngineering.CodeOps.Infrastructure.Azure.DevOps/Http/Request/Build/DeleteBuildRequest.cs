using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class DeleteBuildRequest : ApiRequest
    {
        public DeleteBuildRequest(string organization, string project, int buildId)
        {
            ApiVersion = "6.1-preview.6";
            Method = HttpMethod.Delete;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/{buildId}?api-version={ApiVersion}");
        }
    }
}
