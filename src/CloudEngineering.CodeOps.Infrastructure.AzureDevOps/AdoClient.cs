using CloudEngineering.CodeOps.Abstractions.Protocols.Http;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Profile;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Shared;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build.Definition;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Profile;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Project;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps
{
    //TODO: Implement Facade & Command patterns to break up class before it turns into Godzilla
    public sealed class AdoClient : RestClient, IAdoClient
    {
        private readonly IOptions<AdoClientOptions> _options;

        public AdoClient(IOptions<AdoClientOptions> options) : base(new SocketsHttpHandler())
        {
            _options = options;
        }

        private AuthenticationHeaderValue GetAuthZHeader()
        {
            if (Regex.IsMatch(_options.Value.ClientSecret, JwtConstants.JsonCompactSerializationRegex) || Regex.IsMatch(_options.Value.ClientSecret, JwtConstants.JweCompactSerializationRegex))
            {
                return new AuthenticationHeaderValue("Bearer", _options.Value.ClientSecret);
            }
            else
            {
                return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format(":{0}", _options.Value.ClientSecret))));
            }
        }

        public async Task<ReleaseDto> GetRelease(string projectIdentifier, int releaseId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetReleaseRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, releaseId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var releaseDto = await response.Content.ReadFromJsonAsync<ReleaseDto>(null, cancellationToken);

            return releaseDto;
        }

        public async Task<ProfileDto> GetProfile(string profileIdentifier, CancellationToken cancellationToken = default)
        {
            var request = new GetProfileRequest(profileIdentifier);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var profileDto = await response.Content.ReadFromJsonAsync<ProfileDto>(null, cancellationToken);

            return profileDto;
        }

        public async Task<BuildDefinitionDto> UpdateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new UpdateBuildDefinitionRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definition);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var definitionDto = await response.Content.ReadFromJsonAsync<BuildDefinitionDto>(null, cancellationToken);

            return definitionDto;
        }

        public async Task<BuildDefinitionDto> GetBuildDefinition(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetBuildDefinitionRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definitionId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var definitionDto = await response.Content.ReadFromJsonAsync<BuildDefinitionDto>(null, cancellationToken);

            return definitionDto;
        }

        public async Task<string> GetBuildDefinitionYaml(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetBuildDefinitionYamlRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definitionId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            return responseData;
        }

        public async Task<BuildDefinitionDto> CreateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new UpdateBuildDefinitionRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definition);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var definitionDto = await response.Content.ReadFromJsonAsync<BuildDefinitionDto>(null, cancellationToken);

            return definitionDto;
        }

        public async Task<BuildDto> QueueBuild(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new UpdateBuildDefinitionRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definition);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var buildDto = await response.Content.ReadFromJsonAsync<BuildDto>(null, cancellationToken);

            return buildDto;
        }

        public async Task<BuildDto> QueueBuild(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new QueueBuildRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, definitionId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var buildDto = await response.Content.ReadFromJsonAsync<BuildDto>(null, cancellationToken);

            return buildDto;
        }

        public async Task<OperationDto> CreateProject(ProjectDto project, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new CreateProjectRequest(organization ?? _options.Value.DefaultOrganization, project);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var operationReferenceDto = await response.Content.ReadFromJsonAsync<OperationDto>(null, cancellationToken);

            return operationReferenceDto;
        }

        public async Task<OperationDto> UpdateProject(ProjectDto project, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new UpdateProjectRequest(organization ?? _options.Value.DefaultOrganization, project);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var operationReferenceDto = await response.Content.ReadFromJsonAsync<OperationDto>(null, cancellationToken);

            return operationReferenceDto;
        }

        public async Task<ProjectDto> GetProject(string projectIdentifier, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetProjectRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var projectDto = await response.Content.ReadFromJsonAsync<ProjectDto>(null, cancellationToken);

            return projectDto;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjects(string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetProjectsRequest(organization ?? _options.Value.DefaultOrganization);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var projectDtos = await response.Content.ReadFromJsonAsync<VstsListResult<List<ProjectDto>>>(null, cancellationToken);

            return projectDtos.Value;
        }

        public async Task<BuildDto> GetBuild(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetBuildRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, buildId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var buildDto = await response.Content.ReadFromJsonAsync<BuildDto>(null, cancellationToken);

            return buildDto;
        }

        public async Task DeleteBuild(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetBuildRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, buildId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new AdoClientException("Could not find requested buildId");
            }

            return;
        }

        public async Task<BuildDto> UpdateBuild(string projectIdentifier, BuildDto build, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new UpdateBuildRequest(organization ?? _options.Value.DefaultOrganization, projectIdentifier, build);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var buildDto = await response.Content.ReadFromJsonAsync<BuildDto>(null, cancellationToken);

            return buildDto;
        }

        public async Task<IEnumerable<ChangeDto>> GetBuildChanges(string projectIdentifier, int fromBuildId, int toBuildId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetChangesBetweenBuilds(organization ?? _options.Value.DefaultOrganization, projectIdentifier, fromBuildId, toBuildId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var changeDtos = await response.Content.ReadFromJsonAsync<VstsListResult<List<ChangeDto>>>(null, cancellationToken);

            return changeDtos.Value;
        }

        public async Task<IEnumerable<WorkItemDto>> GetBuildWorkItemRefs(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default)
        {
            var request = new GetBuildWorkItemRefs(organization ?? _options.Value.DefaultOrganization, projectIdentifier, buildId);

            request.Headers.Authorization = GetAuthZHeader();

            var response = await SendAsync(request, cancellationToken);
            var workItemDtos = await response.Content.ReadFromJsonAsync<VstsListResult<List<WorkItemDto>>>(null, cancellationToken);

            return workItemDtos.Value;
        }

        private class VstsListResult<T>
        {
            [JsonPropertyName("value")]
            public T Value { get; set; }
        }
    }
}
