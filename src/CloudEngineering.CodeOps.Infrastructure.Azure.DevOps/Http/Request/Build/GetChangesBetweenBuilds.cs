using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class GetChangesBetweenBuilds : ApiRequest
    {
        public GetChangesBetweenBuilds(string organization, string project, int fromBuildId, int toBuildId)
        {
            ApiVersion = "6.1-preview.2";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/changes?api-version={ApiVersion}&fromBuildId={fromBuildId}&toBuildId={toBuildId}");
        }
    }
}
