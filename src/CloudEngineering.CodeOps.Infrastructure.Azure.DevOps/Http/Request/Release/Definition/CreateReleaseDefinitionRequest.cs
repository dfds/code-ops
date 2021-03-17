using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release.Definition
{
    public sealed class CreateReleaseDefinitionRequest : ApiRequest
    {
        public CreateReleaseDefinitionRequest(string organization, string project, ReleaseDefinitionDto definition) : this(organization, project)
        {
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }

        public CreateReleaseDefinitionRequest(string organization, string project)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/definitions?api-version={ApiVersion}");
        }
    }
}
