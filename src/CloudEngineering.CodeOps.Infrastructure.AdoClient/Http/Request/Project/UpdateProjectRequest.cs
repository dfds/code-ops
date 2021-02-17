using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects;
using System;
using System.Net.Http;
using System.Text.Json;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Project;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Http.Request.Project
{
    public sealed class UpdateProjectRequest : ApiRequest
    {
        public UpdateProjectRequest(string organization, ProjectDto project) : this(organization, project.Id.ToString())
        {
            Content = new StringContent(JsonSerializer.Serialize(project));
        }

        public UpdateProjectRequest(string organization, string projectId)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Patch;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects/{projectId}?api-version={ApiVersion}");
        }
    }
}
