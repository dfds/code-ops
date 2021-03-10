using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Release;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release.Definition
{
    public sealed class UpdateReleaseDefinitionRequest : ApiRequest
    {
        public UpdateReleaseDefinitionRequest(string organization, string project, ReleaseDefinitionDto definition) : this(organization, project)
        {
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }

        public UpdateReleaseDefinitionRequest(string organization, string project)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Put;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/definitions?api-version={ApiVersion}");
        }
    }
}