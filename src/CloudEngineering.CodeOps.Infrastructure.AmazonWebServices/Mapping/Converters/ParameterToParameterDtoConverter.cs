using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters
{
    public class ParameterToParameterDtoConverter : ITypeConverter<Parameter, ParameterDto>
    {
        public ParameterDto Convert(Parameter source, ParameterDto destination, ResolutionContext context)
        {
            destination ??= new ParameterDto();

            destination.Name = source.Name;
            destination.Value = source.Value;
            destination.ParamType = source.Type.Value;
            destination.Version = source.Version;

            return destination;
        }
    }
}