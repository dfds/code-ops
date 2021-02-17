using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events;
using System;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Converters
{
    public class WebHookEventToVstsDtoConverter : ITypeConverter<WebHookEvent, AdoDto>
    {
        private readonly IAdoClient _vstsClient;

        public WebHookEventToVstsDtoConverter(IAdoClient vstsClient) 
        {
            _vstsClient = vstsClient;
        }

        public AdoDto Convert(WebHookEvent source, AdoDto destination, ResolutionContext context)
        {
            Guid? projectId;

            switch(source.EventType)
            {
                case BuildCompletedEvent.EventIdentifier:
                    var buildId = source.Resource?.GetProperty("id").GetInt32();
                    projectId = source.ResourceContainers?.GetProperty("project").GetProperty("id").GetGuid();
                    var fetchUpdatedBuildDtoTask = _vstsClient.GetBuild(projectId.Value.ToString(), buildId.Value);

                    fetchUpdatedBuildDtoTask.Wait();
                    
                    return fetchUpdatedBuildDtoTask.Result;

                case ReleaseCreatedEvent.EventIdentifier:
                case ReleaseCompletedEvent.EventIdentifier:
                case ReleaseAbandonedEvent.EventIdentifier:
                case ReleaseApprovalPendingEvent.EventIdentifier:
                case ReleaseApprovalCompletedEvent.EventIdentifier:
                    var releaseId = source.Resource?.GetProperty("release").GetProperty("id").GetInt32();
                    projectId = source.Resource?.GetProperty("project").GetProperty("id").GetGuid();
                    var fetchUpdatedReleaseDtoTask = _vstsClient.GetRelease(projectId.Value.ToString(), releaseId.Value);

                    fetchUpdatedReleaseDtoTask.Wait();

                    return fetchUpdatedReleaseDtoTask.Result;

                default:
                    return null;
            }
        }
    }
}
