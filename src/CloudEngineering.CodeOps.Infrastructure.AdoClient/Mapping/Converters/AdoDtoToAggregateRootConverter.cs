using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Release;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Mapping.Converters
{
    public class AdoDtoToAggregateRootConverter : ITypeConverter<AdoDto, IAggregateRoot>
    {
        public readonly IMapper _mapper;

        public AdoDtoToAggregateRootConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IAggregateRoot Convert(AdoDto source, IAggregateRoot destination, ResolutionContext context)
        {
            switch (source)
            {
                case BuildDto build:
                    return _mapper.Map<IAggregateRoot>(build);

                case ProjectDto project:
                    return _mapper.Map<IAggregateRoot>(project);

                case ReleaseDto release:
                    return _mapper.Map<IAggregateRoot>(release);
                    
                default:
                    return null;
            }
        }
    }
}
