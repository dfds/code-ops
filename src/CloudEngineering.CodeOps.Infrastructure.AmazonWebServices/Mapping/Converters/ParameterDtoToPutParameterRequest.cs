using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Linq;

namespace CostJanitor.Infrastructure.CostProviders.Aws.Mapping.Converters
{
    public class ParameterDtoToPutParameterRequest : ITypeConverter<ParameterDto, PutParameterRequest>
    {
        private readonly IMapper _mapper;

        public PutParameterRequest Convert(ParameterDto source, PutParameterRequest destination, ResolutionContext context)
        {
            destination ??= new PutParameterRequest();

            destination.Name = source.Name;
            destination.Value = source.Value;
            destination.Type = source.ParamType;
            destination.Overwrite = source.Overwrite;
            destination.Tags = source.Tags.Select(kv => new Tag { Key = kv.Key, Value = kv.Value }).ToList();

            return destination;
        }
    }
}