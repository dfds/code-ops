using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters
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
            return source switch
            {
                BuildDto build => _mapper.Map<IAggregateRoot>(build),
                ProjectDto project => _mapper.Map<IAggregateRoot>(project),
                ReleaseDto release => _mapper.Map<IAggregateRoot>(release),
                _ => null,
            };
        }
    }
}
