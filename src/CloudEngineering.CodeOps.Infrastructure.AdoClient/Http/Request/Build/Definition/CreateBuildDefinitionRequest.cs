using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects;
using System;
using System.Net.Http;
using System.Text.Json;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Build;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Http.Request.Build.Definition
{
    public sealed class CreateBuildDefinitionRequest : ApiRequest
    {
        public CreateBuildDefinitionRequest(string organization, string project, BuildDefinitionDto definition)
        {
            ApiVersion = "6.1-preview.7";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/definitions?api-version={ApiVersion}");
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }
    }
}
