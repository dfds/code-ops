using CloudEngineering.CodeOps.Abstractions.Protocols.Http;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Profile;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts
{
    public interface IVstsClient : IRestClient
    {
        Task<ReleaseDto> GetRelease(string projectIdentifier, int releaseId, string organization = default, CancellationToken cancellationToken = default);

        Task<ProjectDto> GetProject(string projectIdentifier, string organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProjectDto>> GetProjects(string organization = default, CancellationToken cancellationToken = default);

        Task<OperationDto> CreateProject(ProjectDto project, string organization = default, CancellationToken cancellationToken = default);

        Task<OperationDto> UpdateProject(ProjectDto project, string organization = default, CancellationToken cancellationToken = default);

        Task<ProfileDto> GetProfile(string profileIdentifier, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto> GetBuildDefinition(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default);

        Task<string> GetBuildDefinitionYaml(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto> CreateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto> UpdateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto> GetBuild(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<ChangeDto>> GetBuildChanges(string projectIdentifier, int fromBuildId, int toBuildId, string organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<WorkItemDto>> GetBuildWorkItemRefs(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default);

        Task DeleteBuild(string projectIdentifier, int buildId, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto> UpdateBuild(string projectIdentifier, BuildDto build, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto> QueueBuild(string projectIdentifier, int definitionId, string organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto> QueueBuild(string projectIdentifier, BuildDefinitionDto definition, string organization = default, CancellationToken cancellationToken = default);
    }
}