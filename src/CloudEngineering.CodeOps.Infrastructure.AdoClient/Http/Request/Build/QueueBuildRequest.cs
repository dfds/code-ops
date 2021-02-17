using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Build;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Http.Request.Build
{
    public sealed class QueueBuildRequest : ApiRequest
    {
        public QueueBuildRequest(string organization, string project, BuildDefinitionDto definition) : this(organization, project, definition.Id)
        {
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }

        public QueueBuildRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/builds?api-version={ApiVersion}&definitionId={definitionId}");
        }
    }
}
