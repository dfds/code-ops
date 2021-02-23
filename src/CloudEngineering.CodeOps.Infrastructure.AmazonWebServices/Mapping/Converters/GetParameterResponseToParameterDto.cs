using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;

namespace CostJanitor.Infrastructure.CostProviders.Aws.Mapping.Converters
{
    public class GetParameterResponseToParameterDto : ITypeConverter<GetParameterResponse, ParameterDto>
    {
        private readonly IMapper _mapper;

        public ParameterDto Convert(GetParameterResponse source, ParameterDto destination, ResolutionContext context)
        {
            destination ??= new ParameterDto();
            destination = _mapper.Map(source.Parameter, destination);

            destination.ParamType = source.Parameter.Type.Value;

            return destination;
        }
    }
}