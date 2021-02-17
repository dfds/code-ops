using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Project;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Http.Request.Project
{
    public sealed class CreateProjectRequest : ApiRequest
    {
        public CreateProjectRequest(string organization, ProjectDto project) : this(organization)
        {
            Content = new StringContent(JsonSerializer.Serialize(project));
        }

        public CreateProjectRequest(string organization)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects?api-version={ApiVersion}");
        }
    }
}
