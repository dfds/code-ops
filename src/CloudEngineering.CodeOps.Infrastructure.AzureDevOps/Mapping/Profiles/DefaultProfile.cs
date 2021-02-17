using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Converters;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<JsonElement, WebHookEvent>()
            .ConvertUsing<JsonElementToWebHookEventConverter>();

            CreateMap<WebHookEvent, AdoDto>()
            .ConvertUsing<WebHookEventToVstsDtoConverter>();

            CreateMap<AdoDto, IAggregateRoot>()
            .ConvertUsing<AdoDtoToAggregateRootConverter>();
        }
    }
}
