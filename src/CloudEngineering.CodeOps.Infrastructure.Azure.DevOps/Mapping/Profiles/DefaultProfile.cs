using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<JsonElement, AdoEvent>()
            .ConvertUsing<JsonElementToAdoEventConverter>();

            CreateMap<AdoEvent, AdoDto>()
            .ConvertUsing<AdoEventToAdoDtoConverter>();

            CreateMap<AdoDto, IAggregateRoot>()
            .ConvertUsing<AdoDtoToAggregateRootConverter>();
        }
    }
}
