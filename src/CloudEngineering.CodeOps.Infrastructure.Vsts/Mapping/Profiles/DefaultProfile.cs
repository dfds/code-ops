using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Vsts.Events;
using CloudEngineering.CodeOps.Infrastructure.Vsts.Mapping.Converters;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<JsonElement, WebHookEvent>()
            .ConvertUsing<JsonElementToWebHookEventConverter>();

            CreateMap<WebHookEvent, VstsDto>()
            .ConvertUsing<WebHookEventToVstsDtoConverter>();

            CreateMap<VstsDto, IAggregateRoot>()
            .ConvertUsing<VstsDtoToAggregateRootConverter>();
        }
    }
}
