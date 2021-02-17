using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Release;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Mapping.Converters
{
    public class VstsDtoToAggregateRootConverter : ITypeConverter<VstsDto, IAggregateRoot>
    {
        public readonly IMapper _mapper;

        public VstsDtoToAggregateRootConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IAggregateRoot Convert(VstsDto source, IAggregateRoot destination, ResolutionContext context)
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
