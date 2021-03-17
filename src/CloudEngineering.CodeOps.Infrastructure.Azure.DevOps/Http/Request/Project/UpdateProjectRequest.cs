using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project
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
