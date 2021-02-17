using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Http.Request.Release.Definition
{
    public sealed class GetReleaseDefinitionRequest : ApiRequest
    {
        public GetReleaseDefinitionRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/definitions/{definitionId}?api-version={ApiVersion}");
        }
    }
}
