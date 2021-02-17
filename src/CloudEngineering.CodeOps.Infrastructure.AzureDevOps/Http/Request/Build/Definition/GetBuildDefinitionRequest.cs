using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build.Definition
{
    public sealed class GetBuildDefinitionRequest : ApiRequest
    {
        public GetBuildDefinitionRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.1-preview.7";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/definitions/{definitionId}?api-version={ApiVersion}");
        }
    }
}
