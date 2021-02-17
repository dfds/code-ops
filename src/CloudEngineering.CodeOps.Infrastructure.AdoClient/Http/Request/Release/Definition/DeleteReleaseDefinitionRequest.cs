using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release.Definition
{
    public sealed class DeleteReleaseDefinitionRequest : ApiRequest
    {
        public DeleteReleaseDefinitionRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Delete;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/definitions/{definitionId}?api-version={ApiVersion}");
        }
    }
}
