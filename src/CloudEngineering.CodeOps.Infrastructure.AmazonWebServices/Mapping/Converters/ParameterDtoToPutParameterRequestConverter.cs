using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Collections.Generic;
using System.Linq;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters
{
    public class ParameterDtoToPutParameterRequestConverter : ITypeConverter<ParameterDto, PutParameterRequest>, ITypeConverter<PutParameterRequest, ParameterDto>
    {
        public PutParameterRequest Convert(ParameterDto source, PutParameterRequest destination, ResolutionContext context)
        {
            destination ??= new PutParameterRequest();

            destination.Name = source.Name;
            destination.Value = source.Value;
            destination.Type = source.ParamType;
            destination.Overwrite = source.Overwrite;
            destination.Tags = source.Tags?.Select(kv => new Tag { Key = kv.Key, Value = kv.Value }).ToList();

            return destination;
        }

        public ParameterDto Convert(PutParameterRequest source, ParameterDto destination, ResolutionContext context)
        {
            destination ??= new ParameterDto();

            destination.Name = source.Name;
            destination.Value = source.Value;
            destination.ParamType = source.Type.Value;
            destination.Overwrite = source.Overwrite;
            destination.Tags = source.Tags?.Select(tag => new KeyValuePair<string, string>(tag.Key, tag.Value)).ToArray();

            return destination;
        }
    }
}