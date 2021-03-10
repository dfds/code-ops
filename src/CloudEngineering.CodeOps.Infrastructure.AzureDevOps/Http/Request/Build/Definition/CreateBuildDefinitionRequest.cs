using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build.Definition
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
