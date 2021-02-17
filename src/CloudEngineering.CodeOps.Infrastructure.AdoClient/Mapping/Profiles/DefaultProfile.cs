using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.Events;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.Mapping.Converters;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Mapping.Profiles
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
